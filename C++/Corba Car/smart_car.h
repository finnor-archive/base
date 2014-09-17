/*
 *  MICO --- an Open Source CORBA implementation
 *  Copyright (c) 1997-2006 by The Mico Team
 *
 *  This file was automatically generated. DO NOT EDIT!
 */

#include <CORBA.h>
#include <mico/throw.h>

#ifndef __SMART_CAR_H__
#define __SMART_CAR_H__




class Tires;
typedef Tires *Tires_ptr;
typedef Tires_ptr TiresRef;
typedef ObjVar< Tires > Tires_var;
typedef ObjOut< Tires > Tires_out;

class Dashboard;
typedef Dashboard *Dashboard_ptr;
typedef Dashboard_ptr DashboardRef;
typedef ObjVar< Dashboard > Dashboard_var;
typedef ObjOut< Dashboard > Dashboard_out;




/*
 * Base class and common definitions for interface Tires
 */

class Tires : 
  virtual public CORBA::Object
{
  public:
    virtual ~Tires();

    #ifdef HAVE_TYPEDEF_OVERLOAD
    typedef Tires_ptr _ptr_type;
    typedef Tires_var _var_type;
    #endif

    static Tires_ptr _narrow( CORBA::Object_ptr obj );
    static Tires_ptr _narrow( CORBA::AbstractBase_ptr obj );
    static Tires_ptr _duplicate( Tires_ptr _obj )
    {
      CORBA::Object::_duplicate (_obj);
      return _obj;
    }

    static Tires_ptr _nil()
    {
      return 0;
    }

    virtual void *_narrow_helper( const char *repoid );

    virtual CORBA::Short getBrakeAmount() = 0;
    virtual void setBrakeAmount( CORBA::Short amount ) = 0;

  protected:
    Tires() {};
  private:
    Tires( const Tires& );
    void operator=( const Tires& );
};

// Stub for interface Tires
class Tires_stub:
  virtual public Tires
{
  public:
    virtual ~Tires_stub();
    CORBA::Short getBrakeAmount();
    void setBrakeAmount( CORBA::Short amount );

  private:
    void operator=( const Tires_stub& );
};

#ifndef MICO_CONF_NO_POA

class Tires_stub_clp :
  virtual public Tires_stub,
  virtual public PortableServer::StubBase
{
  public:
    Tires_stub_clp (PortableServer::POA_ptr, CORBA::Object_ptr);
    virtual ~Tires_stub_clp ();
    CORBA::Short getBrakeAmount();
    void setBrakeAmount( CORBA::Short amount );

  protected:
    Tires_stub_clp ();
  private:
    void operator=( const Tires_stub_clp & );
};

#endif // MICO_CONF_NO_POA


/*
 * Base class and common definitions for interface Dashboard
 */

class Dashboard : 
  virtual public CORBA::Object
{
  public:
    virtual ~Dashboard();

    #ifdef HAVE_TYPEDEF_OVERLOAD
    typedef Dashboard_ptr _ptr_type;
    typedef Dashboard_var _var_type;
    #endif

    static Dashboard_ptr _narrow( CORBA::Object_ptr obj );
    static Dashboard_ptr _narrow( CORBA::AbstractBase_ptr obj );
    static Dashboard_ptr _duplicate( Dashboard_ptr _obj )
    {
      CORBA::Object::_duplicate (_obj);
      return _obj;
    }

    static Dashboard_ptr _nil()
    {
      return 0;
    }

    virtual void *_narrow_helper( const char *repoid );

    virtual void reportFriction( CORBA::Short friction ) = 0;
    virtual void reportBrakeTemperature( CORBA::Float temp ) = 0;
    virtual void reportCarTemperature( CORBA::Float temp ) = 0;

  protected:
    Dashboard() {};
  private:
    Dashboard( const Dashboard& );
    void operator=( const Dashboard& );
};

// Stub for interface Dashboard
class Dashboard_stub:
  virtual public Dashboard
{
  public:
    virtual ~Dashboard_stub();
    void reportFriction( CORBA::Short friction );
    void reportBrakeTemperature( CORBA::Float temp );
    void reportCarTemperature( CORBA::Float temp );

  private:
    void operator=( const Dashboard_stub& );
};

#ifndef MICO_CONF_NO_POA

class Dashboard_stub_clp :
  virtual public Dashboard_stub,
  virtual public PortableServer::StubBase
{
  public:
    Dashboard_stub_clp (PortableServer::POA_ptr, CORBA::Object_ptr);
    virtual ~Dashboard_stub_clp ();
    void reportFriction( CORBA::Short friction );
    void reportBrakeTemperature( CORBA::Float temp );
    void reportCarTemperature( CORBA::Float temp );

  protected:
    Dashboard_stub_clp ();
  private:
    void operator=( const Dashboard_stub_clp & );
};

#endif // MICO_CONF_NO_POA

#ifndef MICO_CONF_NO_POA

class POA_Tires : virtual public PortableServer::StaticImplementation
{
  public:
    virtual ~POA_Tires ();
    Tires_ptr _this ();
    bool dispatch (CORBA::StaticServerRequest_ptr);
    virtual void invoke (CORBA::StaticServerRequest_ptr);
    virtual CORBA::Boolean _is_a (const char *);
    virtual CORBA::InterfaceDef_ptr _get_interface ();
    virtual CORBA::RepositoryId _primary_interface (const PortableServer::ObjectId &, PortableServer::POA_ptr);

    virtual void * _narrow_helper (const char *);
    static POA_Tires * _narrow (PortableServer::Servant);
    virtual CORBA::Object_ptr _make_stub (PortableServer::POA_ptr, CORBA::Object_ptr);

    virtual CORBA::Short getBrakeAmount() = 0;
    virtual void setBrakeAmount( CORBA::Short amount ) = 0;

  protected:
    POA_Tires () {};

  private:
    POA_Tires (const POA_Tires &);
    void operator= (const POA_Tires &);
};

template<class T>
class POA_Tires_tie : 
  virtual public POA_Tie_Base<T>,
  virtual public POA_Tires
{
  public:
    POA_Tires_tie (T &t)
      : POA_Tie_Base<T> (&t, PortableServer::POA::_nil(), FALSE)
    {}
    POA_Tires_tie (T &t, PortableServer::POA_ptr _poa)
      : POA_Tie_Base<T> (&t, _poa, FALSE)
    {}
    POA_Tires_tie (T *t, CORBA::Boolean _rel = TRUE)
      : POA_Tie_Base<T> (t, PortableServer::POA::_nil(), _rel)
    {}
    POA_Tires_tie (T *t, PortableServer::POA_ptr _poa, CORBA::Boolean _rel = TRUE)
      : POA_Tie_Base<T> (t, _poa, _rel)
    {}
    virtual ~POA_Tires_tie ();

    PortableServer::POA_ptr _default_POA ();

    CORBA::Short getBrakeAmount();
    void setBrakeAmount( CORBA::Short amount );

  protected:
    POA_Tires_tie () {};

  private:
    POA_Tires_tie (const POA_Tires_tie<T> &);
    void operator= (const POA_Tires_tie<T> &);
};

template<class T>
POA_Tires_tie<T>::~POA_Tires_tie ()
{
}

template<class T>
PortableServer::POA_ptr
POA_Tires_tie<T>::_default_POA ()
{
  if (!CORBA::is_nil (POA_Tie_Base<T>::poa)) {
    return PortableServer::POA::_duplicate (POA_Tie_Base<T>::poa);
  }
  return PortableServer::ServantBase::_default_POA ();
}

template<class T>
CORBA::Short
POA_Tires_tie<T>::getBrakeAmount ()
{
  return POA_Tie_Base<T>::ptr->getBrakeAmount ();
}

template<class T>
void
POA_Tires_tie<T>::setBrakeAmount (CORBA::Short amount)
{
  POA_Tie_Base<T>::ptr->setBrakeAmount (amount);
}

class POA_Dashboard : virtual public PortableServer::StaticImplementation
{
  public:
    virtual ~POA_Dashboard ();
    Dashboard_ptr _this ();
    bool dispatch (CORBA::StaticServerRequest_ptr);
    virtual void invoke (CORBA::StaticServerRequest_ptr);
    virtual CORBA::Boolean _is_a (const char *);
    virtual CORBA::InterfaceDef_ptr _get_interface ();
    virtual CORBA::RepositoryId _primary_interface (const PortableServer::ObjectId &, PortableServer::POA_ptr);

    virtual void * _narrow_helper (const char *);
    static POA_Dashboard * _narrow (PortableServer::Servant);
    virtual CORBA::Object_ptr _make_stub (PortableServer::POA_ptr, CORBA::Object_ptr);

    virtual void reportFriction( CORBA::Short friction ) = 0;
    virtual void reportBrakeTemperature( CORBA::Float temp ) = 0;
    virtual void reportCarTemperature( CORBA::Float temp ) = 0;

  protected:
    POA_Dashboard () {};

  private:
    POA_Dashboard (const POA_Dashboard &);
    void operator= (const POA_Dashboard &);
};

template<class T>
class POA_Dashboard_tie : 
  virtual public POA_Tie_Base<T>,
  virtual public POA_Dashboard
{
  public:
    POA_Dashboard_tie (T &t)
      : POA_Tie_Base<T> (&t, PortableServer::POA::_nil(), FALSE)
    {}
    POA_Dashboard_tie (T &t, PortableServer::POA_ptr _poa)
      : POA_Tie_Base<T> (&t, _poa, FALSE)
    {}
    POA_Dashboard_tie (T *t, CORBA::Boolean _rel = TRUE)
      : POA_Tie_Base<T> (t, PortableServer::POA::_nil(), _rel)
    {}
    POA_Dashboard_tie (T *t, PortableServer::POA_ptr _poa, CORBA::Boolean _rel = TRUE)
      : POA_Tie_Base<T> (t, _poa, _rel)
    {}
    virtual ~POA_Dashboard_tie ();

    PortableServer::POA_ptr _default_POA ();

    void reportFriction( CORBA::Short friction );
    void reportBrakeTemperature( CORBA::Float temp );
    void reportCarTemperature( CORBA::Float temp );

  protected:
    POA_Dashboard_tie () {};

  private:
    POA_Dashboard_tie (const POA_Dashboard_tie<T> &);
    void operator= (const POA_Dashboard_tie<T> &);
};

template<class T>
POA_Dashboard_tie<T>::~POA_Dashboard_tie ()
{
}

template<class T>
PortableServer::POA_ptr
POA_Dashboard_tie<T>::_default_POA ()
{
  if (!CORBA::is_nil (POA_Tie_Base<T>::poa)) {
    return PortableServer::POA::_duplicate (POA_Tie_Base<T>::poa);
  }
  return PortableServer::ServantBase::_default_POA ();
}

template<class T>
void
POA_Dashboard_tie<T>::reportFriction (CORBA::Short friction)
{
  POA_Tie_Base<T>::ptr->reportFriction (friction);
}

template<class T>
void
POA_Dashboard_tie<T>::reportBrakeTemperature (CORBA::Float temp)
{
  POA_Tie_Base<T>::ptr->reportBrakeTemperature (temp);
}

template<class T>
void
POA_Dashboard_tie<T>::reportCarTemperature (CORBA::Float temp)
{
  POA_Tie_Base<T>::ptr->reportCarTemperature (temp);
}

#endif // MICO_CONF_NO_POA

extern CORBA::StaticTypeInfo *_marshaller_Tires;

extern CORBA::StaticTypeInfo *_marshaller_Dashboard;

#endif
