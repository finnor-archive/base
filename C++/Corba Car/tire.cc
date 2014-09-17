////////////////////////////////
// Smart Car CORBA Project
// Peter Roe, Adrian Flannery
// CS 581 -- 10 Oct., 2012
////////////////////////////////

/*
 * Simple Tire server. The Tire server implements the
 * Tires interface. The server receives brake amount updates from the
 * Brake client and stores the updated brake amount. The Tire
 * server also receives requests from the Sensor client to get the
 * current brake amount.
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
 * Implementation of the Tires interface.
 */
class Tires_impl: virtual public POA_Tires {
public:
	Tires_impl();

	short getBrakeAmount();
	void setBrakeAmount(short amount);

private:
	short brakeAmount;

	void updateDisplay(short amount);
};

/*
 * Tire constructor. Initialize the current brake amount.
 */
Tires_impl::Tires_impl() {
	brakeAmount = 0;
}

/*
 * Get the current brake amount. Called by the Sensor client.
 */
short Tires_impl::getBrakeAmount() {
	return brakeAmount;
}

/*
 * Set the brake amount. Called by the Brake client.
 */
void Tires_impl::setBrakeAmount(short amount) {
	brakeAmount = amount;
	updateDisplay(brakeAmount);
}

/*
 * Update the display to indicate that a new brake amount has been
 * received.
 */
void Tires_impl::updateDisplay(short amount) {
	cout << "[" << time(NULL) << "]" << "Received brake amount: " << amount
			<< endl;
}

/*
 * Driver for the Tire server. Instantiates a Tires_impl,
 * connects it to the naming service, and runs it.
 */
int main(int argc, char *argv[]) {
	// Initialize the ORB.
	CORBA::ORB_var orb = CORBA::ORB_init(argc, argv);

	// Get the root POA and POA manager.
	CORBA::Object_var poaobj = orb->resolve_initial_references("RootPOA");
	PortableServer::POA_var poa = PortableServer::POA::_narrow(poaobj);
	PortableServer::POAManager_var mgr = poa->the_POAManager();

	// Create a Tires object.
	Tires_impl *tires = new Tires_impl;

	// Activate the servant.
	PortableServer::ObjectId_var oid_tires = poa->activate_object(tires);
	CORBA::Object_var ref = poa->id_to_reference(oid_tires.in());

	// Get a reference to the naming service.
	CORBA::Object_var nsobj;

	nsobj = orb->resolve_initial_references("NameService");

	CosNaming::NamingContext_var nc = CosNaming::NamingContext::_narrow(nsobj);

	if (CORBA::is_nil(nc)) {
		cerr << "Cannot access the naming service." << endl;
		exit(1);
	}

	// Initialize the naming service.
	CosNaming::Name name;
	name.length(1);
	name[0].id = CORBA::string_dup("Tires");
	name[0].kind = CORBA::string_dup("");

	// Store a reference to the Tire server in the naming service.
	cout << "Binding Tire server to the naming service ... " << flush;
	nc->rebind(name, ref);
	cout << "done." << endl;

	// Activate the POA and begin servicing requests.
	cout << "Tire server running." << endl;

	mgr->activate();
	orb->run();

	// Shutdown the POA.
	poa->destroy(TRUE, TRUE);

	return 0;
}
