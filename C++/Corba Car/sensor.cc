////////////////////////////////
// Smart Car CORBA Project
// Peter Roe, Adrian Flannery
// CS 581 -- 10 Oct., 2012
////////////////////////////////

#include <CORBA.h>
#include <coss/CosNaming.h>

#include "smart_car.h"

#ifdef HAVE_UNISTD_H
#include <unistd.h>
#endif

#ifdef _WIN32
#include <direct.h>
#endif

#include <time.h>
#include <pthread.h>

using namespace std;

/*
 * Sensor base class. Contains a reference to the Dashboard and Tire
 * objects. Gets the references from the naming service.
 */
class Sensor {
public:
	Sensor(int &argc, char **argv) {
		// Initialize the ORB.
		orb = CORBA::ORB_init(argc, argv);

		// Get a reference to the naming service.
		CORBA::Object_var nsobj = orb->resolve_initial_references(
				"NameService");

		CosNaming::NamingContext_var nc = CosNaming::NamingContext::_narrow(
				nsobj);

		if (CORBA::is_nil(nc)) {
			cerr << "Cannot access the naming service." << endl;
			exit(1);
		}

		// Initialize the naming service.
		CosNaming::Name dashboard_name;
		dashboard_name.length(1);
		dashboard_name[0].id = CORBA::string_dup("Dashboard");
		dashboard_name[0].kind = CORBA::string_dup("");

		CosNaming::Name tire_name;
		tire_name.length(1);
		tire_name[0].id = CORBA::string_dup("Tires");
		tire_name[0].kind = CORBA::string_dup("");

		// Find a reference to the Dashboard and Tires servers in the naming service.
#ifdef HAVE_EXCEPTIONS
		try {
			dashboard_obj = nc->resolve (dashboard_name);
			tire_obj = nc->resolve (tire_name);
		}
		catch (CosNaming::NamingContext::NotFound &exc) {
			cout << "NotFound exception." << endl;
			exit (1);
		}
		catch (CosNaming::NamingContext::CannotProceed &exc) {
			cout << "CannotProceed exception." << endl;
			exit (1);
		}
		catch (CosNaming::NamingContext::InvalidName &exc) {
			cout << "InvalidName exception." << endl;
			exit (1);
		}
#else
		dashboard_obj = nc->resolve(dashboard_name);
		tire_obj = nc->resolve(tire_name);
#endif

		// Get a reference to the Dashboard and Tires servers.
		dashboard = Dashboard::_narrow(dashboard_obj);
		tires = Tires::_narrow(tire_obj);

		if (CORBA::is_nil(dashboard)) {
			printf("Cannot connect to Dashboard server.\n");
			exit(1);
		}

		if (CORBA::is_nil(tires)) {
			printf("Cannot connect to Tire server.\n");
			exit(1);
		}

	}

	void update() {
	}
	;

protected:

	CORBA::ORB_var orb;
	CORBA::Object_var dashboard_obj;
	CORBA::Object_var tire_obj;
	Dashboard_var dashboard;
	Tires_var tires;
};

/*
 * Brake Friction Sensor derived class. Gets the brake amount from the
 * Tires server and calculates a friction value from it. Sends the
 * friction value to the Dashboard server.
 */
class BrakeFrictionSensor: public Sensor {
public:
	BrakeFrictionSensor(int &argc, char **argv) :
			Sensor(argc, argv) {
		cout << "Initializing brake friction sensor..." << endl;
	}

  /*
   * Poll the Tire server to get the current brake amount. Use the
   * received brake amount to calculate the friction value. Send the
   * friction valule to the Dashboard server.
   */
	void update() {
		short brakeAmount = tires->getBrakeAmount();

		short friction = brakeAmount * 10;

		cout << "[" << time(NULL) << "]" << "Calculated new friction: "
				<< friction << endl;

		dashboard->reportFriction(friction);
	}
};

/*
 * Brake Temperature Sensor derived class. Gets the brake amount from
 * the Tires server and calculates a temperature value from it. Sends
 * the temperature value to the Dashboard server.
 */
class BrakeTemperatureSensor: public Sensor {
public:
	BrakeTemperatureSensor(int &argc, char **argv) :
			Sensor(argc, argv) {
		cout << "Initializing brake temperature sensor..." << endl;
	}

  /*
   * Poll the Tire server to get the current brake amount. Use the
   * received brake amount to calculate the temperature value. Send the
   * temperature valule to the Dashboard server.
   */
	void update() {
		short brakeAmount = tires->getBrakeAmount();

		short temp = brakeAmount * 30;

		cout << "[" << time(NULL) << "]" << "Calculated new brake temperature: "
				<< temp << endl;

		dashboard->reportBrakeTemperature(temp);
	}
};

/*
 * Car Temperature Sensor derived class. Calculates a random temperature
 * value between 70 and 80 degrees and sends it to the Dashboard server.
 */
class CarTemperatureSensor: public Sensor {
public:
	CarTemperatureSensor(int &argc, char **argv) :
			Sensor(argc, argv) {
		cout << "Initializing car temperature sensor..." << endl;
	}

  /*
   * Calculate a randow temperature value between 70 and 80 degrees.
   * Send the temperature valule to the Dashboard server.
   */
	void update() {
		float temp = (rand() % 10) + 70.0;

		cout << "[" << time(NULL) << "]" << "Calculated new car temperature: "
				<< temp << endl;

		dashboard->reportCarTemperature(temp);
	}
};

/*
 * Driver for the Sensor client. Instantiates a BrakeFrictionSensor, a
 * BrakeTemperatureSensor, and a CarTemperatureSensor. The driver then
 * runs in a loop, calling each sensor's udpate method every two
 * seconds. The decision was made to use a polling approach to more
 * closely imitate how real tire/brake sensors would actually work. Each
 * sensor's udpate method get the current brake amount from the Tires
 * server and then sends the friction/temperature values to the
 * Dashboard server.
 */
int main(int argc, char *argv[]) {
  // Initialize the sensor objects.
	BrakeFrictionSensor bfs = BrakeFrictionSensor(argc, argv);
	BrakeTemperatureSensor bts = BrakeTemperatureSensor(argc, argv);
	CarTemperatureSensor cts = CarTemperatureSensor(argc, argv);

  // Initialize the time.
	time_t currentTime = time(NULL);

  // Start the event loop.
	while (true) {
		time_t nextTime = time(NULL);

    // Update the sensors every two seconds.
		if ((nextTime - currentTime) >= 2) {
			currentTime = nextTime;

			bfs.update();
			bts.update();
			cts.update();
		}
	}

	return 0;
}
