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
 * Brakes base class. Contains a reference to the Tire object. Gets the
 * reference from the naming service. Each Sensor subclass will have its
 * own reference to the ORB and the Tire.
 */
class Brakes {
public:
  /*
   * Brakes constructor. Initialize the ORB.
   */
	Brakes(int &argc, char **argv) {
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
		CosNaming::Name name;
		name.length(1);
		name[0].id = CORBA::string_dup("Tires");
		name[0].kind = CORBA::string_dup("");

		// Find a reference to the Tires server in the naming service.
#ifdef HAVE_EXCEPTIONS
		try {
			obj = nc->resolve (name);
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
		obj = nc->resolve(name);
#endif

		// Get a reference to the Tire server.
		tires = Tires::_narrow(obj);

		if (CORBA::is_nil(tires)) {
			printf("Cannot connect to Tire server.\n");
			exit(1);
		}
	}

  /*
   * Send the current brake amount to the Tire server.
   */
	void update(short amount) {
		tires->setBrakeAmount(amount);
	}

protected:

	CORBA::ORB_var orb;
	CORBA::Object_var obj;
	Tires_var tires;
};

/*
 * Driver for the Brakes client. Instantiates a Brakes object,
 * waits for user input, and then uses the Brakes client to send the
 * user's brake amount input to the Tires server.
 */
int main(int argc, char *argv[]) {
	cout << "Initializing brakes..." << endl;

  // Initialize the Brakes object.
	Brakes brakes = Brakes(argc, argv);

  // Accept user input.
	while (true) {
		cout << "Enter brake amount: ";

		short amount;

		cin >> amount;

		cout << endl;

		brakes.update(amount);

		system("clear");
	}

	return 0;
}
