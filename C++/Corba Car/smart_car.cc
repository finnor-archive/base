/*
 *  MICO --- an Open Source CORBA implementation
 *  Copyright (c) 1997-2006 by The Mico Team
 *
 *  This file was automatically generated. DO NOT EDIT!
 */

#include <smart_car.h>


using namespace std;

//--------------------------------------------------------
//  Implementation of stubs
//--------------------------------------------------------

/*
 * Base interface for class Tires
 */

Tires::~Tires()
{
}

void *
Tires::_narrow_helper( const char *_repoid )
{
  if( strcmp( _repoid, "IDL:Tires:1.0" ) == 0 )
    return (void *)this;
  return NULL;
}

Tires_ptr
Tires::_narrow( CORBA::Object_ptr _obj )
{
  Tires_ptr _o;
  if( !CORBA::is_nil( _obj ) ) {
    void *_p;
    if( (_p = _obj->_narrow_helper( "IDL:Tires:1.0" )))
      return _duplicate( (Tires_ptr) _p );
    if (!strcmp (_obj->_repoid(), "IDL:Tires:1.0") || _obj->_is_a_remote ("IDL:Tires:1.0")) {
      _o = new Tires_stub;
      _o->CORBA::Object::operator=( *_obj );
      return _o;
    }
  }
  return _nil();
}

Tires_ptr
Tires::_narrow( CORBA::AbstractBase_ptr _obj )
{
  return _narrow (_obj->_to_object());
}

class _Marshaller_Tires : public ::CORBA::StaticTypeInfo {
    typedef Tires_ptr _MICO_T;
  public:
    ~_Marshaller_Tires();
    StaticValueType create () const;
    void assign (StaticValueType dst, const StaticValueType src) const;
    void free (StaticValueType) const;
    void release (StaticValueType) const;
    ::CORBA::Boolean demarshal (::CORBA::DataDecoder&, StaticValueType) const;
    void marshal (::CORBA::DataEncoder &, StaticValueType) const;
};


_Marshaller_Tires::~_Marshaller_Tires()
{
}

::CORBA::StaticValueType _Marshaller_Tires::create() const
{
  return (StaticValueType) new _MICO_T( 0 );
}

void _Marshaller_Tires::assign( StaticValueType d, const StaticValueType s ) const
{
  *(_MICO_T*) d = ::Tires::_duplicate( *(_MICO_T*) s );
}

void _Marshaller_Tires::free( StaticValueType v ) const
{
  ::CORBA::release( *(_MICO_T *) v );
  delete (_MICO_T*) v;
}

void _Marshaller_Tires::release( StaticValueType v ) const
{
  ::CORBA::release( *(_MICO_T *) v );
}

::CORBA::Boolean _Marshaller_Tires::demarshal( ::CORBA::DataDecoder &dc, StaticValueType v ) const
{
  ::CORBA::Object_ptr obj;
  if (!::CORBA::_stc_Object->demarshal(dc, &obj))
    return FALSE;
  *(_MICO_T *) v = ::Tires::_narrow( obj );
  ::CORBA::Boolean ret = ::CORBA::is_nil (obj) || !::CORBA::is_nil (*(_MICO_T *)v);
  ::CORBA::release (obj);
  return ret;
}

void _Marshaller_Tires::marshal( ::CORBA::DataEncoder &ec, StaticValueType v ) const
{
  ::CORBA::Object_ptr obj = *(_MICO_T *) v;
  ::CORBA::_stc_Object->marshal( ec, &obj );
}

::CORBA::StaticTypeInfo *_marshaller_Tires;


/*
 * Stub interface for class Tires
 */

Tires_stub::~Tires_stub()
{
}

#ifndef MICO_CONF_NO_POA

void *
POA_Tires::_narrow_helper (const char * repoid)
{
  if (strcmp (repoid, "IDL:Tires:1.0") == 0) {
    return (void *) this;
  }
  return NULL;
}

POA_Tires *
POA_Tires::_narrow (PortableServer::Servant serv) 
{
  void * p;
  if ((p = serv->_narrow_helper ("IDL:Tires:1.0")) != NULL) {
    serv->_add_ref ();
    return (POA_Tires *) p;
  }
  return NULL;
}

Tires_stub_clp::Tires_stub_clp ()
{
}

Tires_stub_clp::Tires_stub_clp (PortableServer::POA_ptr poa, CORBA::Object_ptr obj)
  : CORBA::Object(*obj), PortableServer::StubBase(poa)
{
}

Tires_stub_clp::~Tires_stub_clp ()
{
}

#endif // MICO_CONF_NO_POA

CORBA::Short Tires_stub::getBrakeAmount()
{
  CORBA::Short _res;
  CORBA::StaticAny __res( CORBA::_stc_short, &_res );

  CORBA::StaticRequest __req( this, "getBrakeAmount" );
  __req.set_result( &__res );

  __req.invoke();

  mico_sii_throw( &__req, 
    0);
  return _res;
}


#ifndef MICO_CONF_NO_POA

CORBA::Short
Tires_stub_clp::getBrakeAmount()
{
  PortableServer::Servant _serv = _preinvoke ();
  if (_serv) {
    POA_Tires * _myserv = POA_Tires::_narrow (_serv);
    if (_myserv) {
      CORBA::Short __res;

      #ifdef HAVE_EXCEPTIONS
      try {
      #endif
        __res = _myserv->getBrakeAmount();
      #ifdef HAVE_EXCEPTIONS
      }
      catch (...) {
        _myserv->_remove_ref();
        _postinvoke();
        throw;
      }
      #endif

      _myserv->_remove_ref();
      _postinvoke ();
      return __res;
    }
    _postinvoke ();
  }

  return Tires_stub::getBrakeAmount();
}

#endif // MICO_CONF_NO_POA

void Tires_stub::setBrakeAmount( CORBA::Short _par_amount )
{
  CORBA::StaticAny _sa_amount( CORBA::_stc_short, &_par_amount );
  CORBA::StaticRequest __req( this, "setBrakeAmount" );
  __req.add_in_arg( &_sa_amount );

  __req.invoke();

  mico_sii_throw( &__req, 
    0);
}


#ifndef MICO_CONF_NO_POA

void
Tires_stub_clp::setBrakeAmount( CORBA::Short _par_amount )
{
  PortableServer::Servant _serv = _preinvoke ();
  if (_serv) {
    POA_Tires * _myserv = POA_Tires::_narrow (_serv);
    if (_myserv) {
      #ifdef HAVE_EXCEPTIONS
      try {
      #endif
        _myserv->setBrakeAmount(_par_amount);
      #ifdef HAVE_EXCEPTIONS
      }
      catch (...) {
        _myserv->_remove_ref();
        _postinvoke();
        throw;
      }
      #endif

      _myserv->_remove_ref();
      _postinvoke ();
      return;
    }
    _postinvoke ();
  }

  Tires_stub::setBrakeAmount(_par_amount);
}

#endif // MICO_CONF_NO_POA


/*
 * Base interface for class Dashboard
 */

Dashboard::~Dashboard()
{
}

void *
Dashboard::_narrow_helper( const char *_repoid )
{
  if( strcmp( _repoid, "IDL:Dashboard:1.0" ) == 0 )
    return (void *)this;
  return NULL;
}

Dashboard_ptr
Dashboard::_narrow( CORBA::Object_ptr _obj )
{
  Dashboard_ptr _o;
  if( !CORBA::is_nil( _obj ) ) {
    void *_p;
    if( (_p = _obj->_narrow_helper( "IDL:Dashboard:1.0" )))
      return _duplicate( (Dashboard_ptr) _p );
    if (!strcmp (_obj->_repoid(), "IDL:Dashboard:1.0") || _obj->_is_a_remote ("IDL:Dashboard:1.0")) {
      _o = new Dashboard_stub;
      _o->CORBA::Object::operator=( *_obj );
      return _o;
    }
  }
  return _nil();
}

Dashboard_ptr
Dashboard::_narrow( CORBA::AbstractBase_ptr _obj )
{
  return _narrow (_obj->_to_object());
}

class _Marshaller_Dashboard : public ::CORBA::StaticTypeInfo {
    typedef Dashboard_ptr _MICO_T;
  public:
    ~_Marshaller_Dashboard();
    StaticValueType create () const;
    void assign (StaticValueType dst, const StaticValueType src) const;
    void free (StaticValueType) const;
    void release (StaticValueType) const;
    ::CORBA::Boolean demarshal (::CORBA::DataDecoder&, StaticValueType) const;
    void marshal (::CORBA::DataEncoder &, StaticValueType) const;
};


_Marshaller_Dashboard::~_Marshaller_Dashboard()
{
}

::CORBA::StaticValueType _Marshaller_Dashboard::create() const
{
  return (StaticValueType) new _MICO_T( 0 );
}

void _Marshaller_Dashboard::assign( StaticValueType d, const StaticValueType s ) const
{
  *(_MICO_T*) d = ::Dashboard::_duplicate( *(_MICO_T*) s );
}

void _Marshaller_Dashboard::free( StaticValueType v ) const
{
  ::CORBA::release( *(_MICO_T *) v );
  delete (_MICO_T*) v;
}

void _Marshaller_Dashboard::release( StaticValueType v ) const
{
  ::CORBA::release( *(_MICO_T *) v );
}

::CORBA::Boolean _Marshaller_Dashboard::demarshal( ::CORBA::DataDecoder &dc, StaticValueType v ) const
{
  ::CORBA::Object_ptr obj;
  if (!::CORBA::_stc_Object->demarshal(dc, &obj))
    return FALSE;
  *(_MICO_T *) v = ::Dashboard::_narrow( obj );
  ::CORBA::Boolean ret = ::CORBA::is_nil (obj) || !::CORBA::is_nil (*(_MICO_T *)v);
  ::CORBA::release (obj);
  return ret;
}

void _Marshaller_Dashboard::marshal( ::CORBA::DataEncoder &ec, StaticValueType v ) const
{
  ::CORBA::Object_ptr obj = *(_MICO_T *) v;
  ::CORBA::_stc_Object->marshal( ec, &obj );
}

::CORBA::StaticTypeInfo *_marshaller_Dashboard;


/*
 * Stub interface for class Dashboard
 */

Dashboard_stub::~Dashboard_stub()
{
}

#ifndef MICO_CONF_NO_POA

void *
POA_Dashboard::_narrow_helper (const char * repoid)
{
  if (strcmp (repoid, "IDL:Dashboard:1.0") == 0) {
    return (void *) this;
  }
  return NULL;
}

POA_Dashboard *
POA_Dashboard::_narrow (PortableServer::Servant serv) 
{
  void * p;
  if ((p = serv->_narrow_helper ("IDL:Dashboard:1.0")) != NULL) {
    serv->_add_ref ();
    return (POA_Dashboard *) p;
  }
  return NULL;
}

Dashboard_stub_clp::Dashboard_stub_clp ()
{
}

Dashboard_stub_clp::Dashboard_stub_clp (PortableServer::POA_ptr poa, CORBA::Object_ptr obj)
  : CORBA::Object(*obj), PortableServer::StubBase(poa)
{
}

Dashboard_stub_clp::~Dashboard_stub_clp ()
{
}

#endif // MICO_CONF_NO_POA

void Dashboard_stub::reportFriction( CORBA::Short _par_friction )
{
  CORBA::StaticAny _sa_friction( CORBA::_stc_short, &_par_friction );
  CORBA::StaticRequest __req( this, "reportFriction" );
  __req.add_in_arg( &_sa_friction );

  __req.invoke();

  mico_sii_throw( &__req, 
    0);
}


#ifndef MICO_CONF_NO_POA

void
Dashboard_stub_clp::reportFriction( CORBA::Short _par_friction )
{
  PortableServer::Servant _serv = _preinvoke ();
  if (_serv) {
    POA_Dashboard * _myserv = POA_Dashboard::_narrow (_serv);
    if (_myserv) {
      #ifdef HAVE_EXCEPTIONS
      try {
      #endif
        _myserv->reportFriction(_par_friction);
      #ifdef HAVE_EXCEPTIONS
      }
      catch (...) {
        _myserv->_remove_ref();
        _postinvoke();
        throw;
      }
      #endif

      _myserv->_remove_ref();
      _postinvoke ();
      return;
    }
    _postinvoke ();
  }

  Dashboard_stub::reportFriction(_par_friction);
}

#endif // MICO_CONF_NO_POA

void Dashboard_stub::reportBrakeTemperature( CORBA::Float _par_temp )
{
  CORBA::StaticAny _sa_temp( CORBA::_stc_float, &_par_temp );
  CORBA::StaticRequest __req( this, "reportBrakeTemperature" );
  __req.add_in_arg( &_sa_temp );

  __req.invoke();

  mico_sii_throw( &__req, 
    0);
}


#ifndef MICO_CONF_NO_POA

void
Dashboard_stub_clp::reportBrakeTemperature( CORBA::Float _par_temp )
{
  PortableServer::Servant _serv = _preinvoke ();
  if (_serv) {
    POA_Dashboard * _myserv = POA_Dashboard::_narrow (_serv);
    if (_myserv) {
      #ifdef HAVE_EXCEPTIONS
      try {
      #endif
        _myserv->reportBrakeTemperature(_par_temp);
      #ifdef HAVE_EXCEPTIONS
      }
      catch (...) {
        _myserv->_remove_ref();
        _postinvoke();
        throw;
      }
      #endif

      _myserv->_remove_ref();
      _postinvoke ();
      return;
    }
    _postinvoke ();
  }

  Dashboard_stub::reportBrakeTemperature(_par_temp);
}

#endif // MICO_CONF_NO_POA

void Dashboard_stub::reportCarTemperature( CORBA::Float _par_temp )
{
  CORBA::StaticAny _sa_temp( CORBA::_stc_float, &_par_temp );
  CORBA::StaticRequest __req( this, "reportCarTemperature" );
  __req.add_in_arg( &_sa_temp );

  __req.invoke();

  mico_sii_throw( &__req, 
    0);
}


#ifndef MICO_CONF_NO_POA

void
Dashboard_stub_clp::reportCarTemperature( CORBA::Float _par_temp )
{
  PortableServer::Servant _serv = _preinvoke ();
  if (_serv) {
    POA_Dashboard * _myserv = POA_Dashboard::_narrow (_serv);
    if (_myserv) {
      #ifdef HAVE_EXCEPTIONS
      try {
      #endif
        _myserv->reportCarTemperature(_par_temp);
      #ifdef HAVE_EXCEPTIONS
      }
      catch (...) {
        _myserv->_remove_ref();
        _postinvoke();
        throw;
      }
      #endif

      _myserv->_remove_ref();
      _postinvoke ();
      return;
    }
    _postinvoke ();
  }

  Dashboard_stub::reportCarTemperature(_par_temp);
}

#endif // MICO_CONF_NO_POA

struct __tc_init_SMART_CAR {
  __tc_init_SMART_CAR()
  {
    _marshaller_Tires = new _Marshaller_Tires;
    _marshaller_Dashboard = new _Marshaller_Dashboard;
  }

  ~__tc_init_SMART_CAR()
  {
    delete static_cast<_Marshaller_Tires*>(_marshaller_Tires);
    delete static_cast<_Marshaller_Dashboard*>(_marshaller_Dashboard);
  }
};

static __tc_init_SMART_CAR __init_SMART_CAR;

//--------------------------------------------------------
//  Implementation of skeletons
//--------------------------------------------------------

// PortableServer Skeleton Class for interface Tires
POA_Tires::~POA_Tires()
{
}

::Tires_ptr
POA_Tires::_this ()
{
  CORBA::Object_var obj = PortableServer::ServantBase::_this();
  return ::Tires::_narrow (obj);
}

CORBA::Boolean
POA_Tires::_is_a (const char * repoid)
{
  if (strcmp (repoid, "IDL:Tires:1.0") == 0) {
    return TRUE;
  }
  return FALSE;
}

CORBA::InterfaceDef_ptr
POA_Tires::_get_interface ()
{
  CORBA::InterfaceDef_ptr ifd = PortableServer::ServantBase::_get_interface ("IDL:Tires:1.0");

  if (CORBA::is_nil (ifd)) {
    mico_throw (CORBA::OBJ_ADAPTER (0, CORBA::COMPLETED_NO));
  }

  return ifd;
}

CORBA::RepositoryId
POA_Tires::_primary_interface (const PortableServer::ObjectId &, PortableServer::POA_ptr)
{
  return CORBA::string_dup ("IDL:Tires:1.0");
}

CORBA::Object_ptr
POA_Tires::_make_stub (PortableServer::POA_ptr poa, CORBA::Object_ptr obj)
{
  return new ::Tires_stub_clp (poa, obj);
}

bool
POA_Tires::dispatch (CORBA::StaticServerRequest_ptr __req)
{
  #ifdef HAVE_EXCEPTIONS
  try {
  #endif
    if( strcmp( __req->op_name(), "getBrakeAmount" ) == 0 ) {
      CORBA::Short _res;
      CORBA::StaticAny __res( CORBA::_stc_short, &_res );
      __req->set_result( &__res );

      if( !__req->read_args() )
        return true;

      _res = getBrakeAmount();
      __req->write_results();
      return true;
    }
    if( strcmp( __req->op_name(), "setBrakeAmount" ) == 0 ) {
      CORBA::Short _par_amount;
      CORBA::StaticAny _sa_amount( CORBA::_stc_short, &_par_amount );

      __req->add_in_arg( &_sa_amount );

      if( !__req->read_args() )
        return true;

      setBrakeAmount( _par_amount );
      __req->write_results();
      return true;
    }
  #ifdef HAVE_EXCEPTIONS
  } catch( CORBA::SystemException_catch &_ex ) {
    __req->set_exception( _ex->_clone() );
    __req->write_results();
    return true;
  } catch( ... ) {
    CORBA::UNKNOWN _ex (CORBA::OMGVMCID | 1, CORBA::COMPLETED_MAYBE);
    __req->set_exception (_ex->_clone());
    __req->write_results ();
    return true;
  }
  #endif

  return false;
}

void
POA_Tires::invoke (CORBA::StaticServerRequest_ptr __req)
{
  if (dispatch (__req)) {
      return;
  }

  CORBA::Exception * ex = 
    new CORBA::BAD_OPERATION (0, CORBA::COMPLETED_NO);
  __req->set_exception (ex);
  __req->write_results();
}


// PortableServer Skeleton Class for interface Dashboard
POA_Dashboard::~POA_Dashboard()
{
}

::Dashboard_ptr
POA_Dashboard::_this ()
{
  CORBA::Object_var obj = PortableServer::ServantBase::_this();
  return ::Dashboard::_narrow (obj);
}

CORBA::Boolean
POA_Dashboard::_is_a (const char * repoid)
{
  if (strcmp (repoid, "IDL:Dashboard:1.0") == 0) {
    return TRUE;
  }
  return FALSE;
}

CORBA::InterfaceDef_ptr
POA_Dashboard::_get_interface ()
{
  CORBA::InterfaceDef_ptr ifd = PortableServer::ServantBase::_get_interface ("IDL:Dashboard:1.0");

  if (CORBA::is_nil (ifd)) {
    mico_throw (CORBA::OBJ_ADAPTER (0, CORBA::COMPLETED_NO));
  }

  return ifd;
}

CORBA::RepositoryId
POA_Dashboard::_primary_interface (const PortableServer::ObjectId &, PortableServer::POA_ptr)
{
  return CORBA::string_dup ("IDL:Dashboard:1.0");
}

CORBA::Object_ptr
POA_Dashboard::_make_stub (PortableServer::POA_ptr poa, CORBA::Object_ptr obj)
{
  return new ::Dashboard_stub_clp (poa, obj);
}

bool
POA_Dashboard::dispatch (CORBA::StaticServerRequest_ptr __req)
{
  #ifdef HAVE_EXCEPTIONS
  try {
  #endif
    if( strcmp( __req->op_name(), "reportFriction" ) == 0 ) {
      CORBA::Short _par_friction;
      CORBA::StaticAny _sa_friction( CORBA::_stc_short, &_par_friction );

      __req->add_in_arg( &_sa_friction );

      if( !__req->read_args() )
        return true;

      reportFriction( _par_friction );
      __req->write_results();
      return true;
    }
    if( strcmp( __req->op_name(), "reportBrakeTemperature" ) == 0 ) {
      CORBA::Float _par_temp;
      CORBA::StaticAny _sa_temp( CORBA::_stc_float, &_par_temp );

      __req->add_in_arg( &_sa_temp );

      if( !__req->read_args() )
        return true;

      reportBrakeTemperature( _par_temp );
      __req->write_results();
      return true;
    }
    if( strcmp( __req->op_name(), "reportCarTemperature" ) == 0 ) {
      CORBA::Float _par_temp;
      CORBA::StaticAny _sa_temp( CORBA::_stc_float, &_par_temp );

      __req->add_in_arg( &_sa_temp );

      if( !__req->read_args() )
        return true;

      reportCarTemperature( _par_temp );
      __req->write_results();
      return true;
    }
  #ifdef HAVE_EXCEPTIONS
  } catch( CORBA::SystemException_catch &_ex ) {
    __req->set_exception( _ex->_clone() );
    __req->write_results();
    return true;
  } catch( ... ) {
    CORBA::UNKNOWN _ex (CORBA::OMGVMCID | 1, CORBA::COMPLETED_MAYBE);
    __req->set_exception (_ex->_clone());
    __req->write_results ();
    return true;
  }
  #endif

  return false;
}

void
POA_Dashboard::invoke (CORBA::StaticServerRequest_ptr __req)
{
  if (dispatch (__req)) {
      return;
  }

  CORBA::Exception * ex = 
    new CORBA::BAD_OPERATION (0, CORBA::COMPLETED_NO);
  __req->set_exception (ex);
  __req->write_results();
}

