(defun add (table name category type value)  
	(COND
		((null table) (LIST (LIST name category type value)))
		((eq (CAAR table) name) nil)
		(T (CONS (addR name category type value (CDR table)) table))
	)
)

(defun addR (name category type value temp)
	(setq ent (CAR temp))   
	(setq rofT (CDR temp)) 
	(COND
		((null ent) (LIST name category type value))
		((eq (CAR ent) name) nil)
		(T (addR name category type value rofT))
	)
)





(defun entry (table name) 
	(setq ent (CAR table))   
	(setq rofT (CDR table))             
	(COND
		((null ent) nil)
		((eq (CAR ent) name) (CDR ent))
		(T (entryR name rofT))
	)
)

(defun entryR (name temp)  
	(setq ent (CAR temp))   
	(setq rofT (CDR temp))               
	(COND
		((null ent) nil)
		((eq (CAR ent) name) (CDR ent))
		(T (entryR name rofT)))
	)
)

		


(defun category (table name)
	(setq ent (CAR table))   
	(setq rofT (CDR table))               
	(COND
		((null ent) nil)
		((eq (CAR ent) name) (CADR ent))
		(T (categoryR name rofT))
	)
)

(defun categoryR (name temp)
	(setq ent (CAR temp))
	(setq rofT (CDR temp))                   
	(COND
		((null ent) nil)
		((eq (CAR ent) name) (CADR ent))
		(T (categoryR name rofT))
	)
)


(defun type (table name)
	(setq ent (CAR table))   
	(setq rofT (CDR table))               
	(COND
		((null ent) nil)
		((eq (CAR ent) name) (CADDR ent))
		(T (typeR name rofT))
	)
)

(defun typeR (name temp)
	(setq ent (CAR temp))
	(setq rofT (CDR temp))                   
	(COND
		((null ent) nil)
		((eq (CAR ent) name) (CADDR ent))
		(T (typeR name rofT))
	)
)

(defun value (table name)
	(setq ent (CAR table))   
	(setq rofT (CDR table))               
	(COND
		((null ent) nil)
		((eq (CAR ent) name) (CADDDR ent))
		(T (valueR name rofT))
	)
)

(defun valueR (name temp)
	(setq ent (CAR temp))
	(setq rofT (CDR temp))                   
	(COND
		((null ent) nil)
		((eq (CAR ent) name) (CADDDR ent))
		(T (valueR name rofT))
	)
)