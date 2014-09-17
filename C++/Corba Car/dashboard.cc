////////////////////////////////
// Smart Car CORBA Project
// Peter Roe, Adrian Flannery
// CS 581 -- 10 Oct., 2012
////////////////////////////////

/*
 * Simple Dashboard server. The Dashboard server implements the
 * Dashboard interface. The server receives sensor updates from the
 * brake friction, brake temperature, and car temperature sensors and
 * displays the updated sensor values on the dashboard.
 */

#include <CORBA.h>
#include <coss/CosNaming.h>

#include "smart_car.h"
#ifdef HAVE_ANSI_CPLUSPLUS_HEADERS
#include <fstream>
#else
#include <fstream.h>
#endif

#include <time.h>

using namespace std;

/*
 * Implementation of the Dashboard interface.
 */
class Dashboard_impl: virtual public POA_Dashboard {
public:
	Dashboard_impl();

	void reportFriction(short friction) throw (CORBA::SystemException);
	void reportBrakeTemperature(float temp) throw (CORBA::SystemException);
	void reportCarTemperature(float temp) throw (CORBA::SystemException);

private:
	short brakeFriction;
	float brakeTemp;
	float carTemp;

	void updateDisplay();
};

/*
 * Dashboard constructor. Initialize the current sensor values.
 */
Dashboard_impl::Dashboard_impl() {
	brakeFriction = 0;
	brakeTemp = 0.0;
	carTemp = 0.0;
}

/*
 * Update the current brake friction value.
 */
void Dashboard_impl::reportFriction(short friction)
		throw (CORBA::SystemException) {
	brakeFriction = friction;
	updateDisplay();
}

/*
 * Udpate the current brake temperature value.
 */
void Dashboard_impl::reportBrakeTemperature(float temp)
		throw (CORBA::SystemException) {
	brakeTemp = temp;
	updateDisplay();
}

/*
 * Update the current car temperature value.
 */
void Dashboard_impl::reportCarTemperature(float temp)
		throw (CORBA::SystemException) {
	carTemp = temp;
	updateDisplay();
}

/*
 * Update the dashboard display with the current sensor values.
 */
void Dashboard_impl::updateDisplay() {
	system("clear");

	cout << "--------------------------------" << endl;

	cout << "Time: " << time(NULL) << endl;
	cout << "Brake friction: " << brakeFriction << endl;
	cout << "Brake temperature: " << brakeTemp << endl;
	cout << "Car temperature: " << carTemp << endl;

	cout << "--------------------------------" << endl;
}

/*
 * Driver for the Dashboard server. Instantiates a Dashboard_impl,
 * connects it to the naming service, and runs it.
 */
int main(int argc, char *argv[]) {
	// Initialize the ORB.
	CORBA::ORB_var orb = CORBA::ORB_init(argc, argv);

	// Get the root POA and POA manager.
	CORBA::Object_var poaobj = orb->resolve_initial_references("RootPOA");
	PortableServer::POA_var poa = PortableServer::POA::_narrow(poaobj);
	PortableServer::POAManager_var mgr = poa->the_POAManager();

	// Create a Dashboard object.
	Dashboard_impl *dashboard = new Dashboard_impl;

	// Activate the servant.
	PortableServer::ObjectId_var oid_dashboard = poa->activate_object(
			dashboard);
	CORBA::Object_var ref = poa->id_to_reference(oid_dashboard.in());

	// Get a reference to the naming service.
	CORBA::Object_var nsobj = orb->resolve_initial_references("NameService");

	CosNaming::NamingContext_var nc = CosNaming::NamingContext::_narrow(nsobj);

	if (CORBA::is_nil(nc)) {
		cerr << "Cannot access the naming service." << endl;
		exit(1);
	}

	// Initialize the naming service.
	CosNaming::Name name;
	name.length(1);
	name[0].id = CORBA::string_dup("Dashboard");
	name[0].kind = CORBA::string_dup("");

	// Store a reference to the Dashboard server in the naming service.
	cout << "Binding Dashboard server to the naming service ... " << flush;
	nc->rebind(name, ref);
	cout << "done." << endl;

	// Activate the POA and begin servicing requests.
	cout << "Dashboard server running." << endl;

	mgr->activate();
	orb->run();

	// Shutdown the POA.
	poa->destroy(TRUE, TRUE);

	return 0;
}
