# The story

There exists a *data store* of *sales orders*, complete with
appropriate *tariffs*.  These orders can be of one of several
*shipping types*.  The lifetime of the order is marked by *events*
(when the order is first created, when it's ready, when it's shipped
and so on).  We care particularly about when the *order is shipped*,
at which point an invoice is generated.