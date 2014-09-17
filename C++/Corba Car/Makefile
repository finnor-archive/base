
all: .depend sensor dashboard tire brakes

DIR_PREFIX=/netshare/courses/cs553/mico/demo/poa/
include /netshare/courses/cs553/mico/demo/MakeVars

CXXFLAGS  := $(COS_CXXFLAGS) $(CXXFLAGS)
LDLIBS    := $(COS_LDLIBS) $(LDLIBS)
LDFLAGS   := $(COS_LDFLAGS) $(LDFLAGS)
DEPS      := $(COS_DEPS) $(DEPS)

PATH := /netshare/courses/cs553/mico/coss/naming:/netshare/courses/cs553/mico:/netshare/courses/cs553/mico/cpp:/netshare/courses/cs553/mico/idl:${PATH}
LD_LIBRARY_PATH := /netshare/courses/cs553/mico/libs:${LD_LIBRARY_PATH}
INCLUDE := /netshare/courses/cs553/mico/include:${INCLUDE}

INSTALL_DIR     = poa/smart_car
INSTALL_SRCS    = Makefile sensor.cc dashboard.cc tire.cc brakes.cc smart_car.idl
INSTALL_SCRIPTS = dashboard_smart_car

dashboard: smart_car.h smart_car.o dashboard.o $(DEPS)
	$(LD) $(CXXFLAGS) $(LDFLAGS) smart_car.o dashboard.o $(LDLIBS) -o dashboard

sensor: dashboard_smart_car.h smart_car.o sensor.o $(DEPS)
	$(LD) $(CXXFLAGS) $(LDFLAGS) smart_car.o sensor.o $(LDLIBS) -o sensor 

tire: smart_car.h smart_car.o tire.o $(DEPS)
	$(LD) $(CXXFLAGS) $(LDFLAGS) smart_car.o tire.o $(LDLIBS) -o tire
	
brakes: dashboard_smart_car.h smart_car.o brakes.o $(DEPS)
	$(LD) $(CXXFLAGS) $(LDFLAGS) smart_car.o brakes.o $(LDLIBS) -o brakes 

dashboard_smart_car.h smart_car.cc : smart_car.idl $(IDLGEN)
	$(IDL) --poa-ties smart_car.idl

run:
	dashboard_smart_car

clean:
	rm -f smart_car.cc smart_car.h *.o core sensor dashboard tire brakes *~ .depend run_dashboard run_sensor run_tire run_brakes
