# ClientSocketConnection

Facilitates
socket
communication
between
a
client
service
and
server
service.
This
package
is
one-directional.
To
connect
to
server,
configure
a
port
number
in
appsettings.json.

###

*
*v1.1.0
**  
[Changed socket Release method]  
*1.*
Changed
socket
to
be
reused
on
disconnect.
*2.*
Removed
closing
the
socket
after
releasing
it.

[Semi-Singleton ClientInitProxy]  
*1.*
Implemented
a
semi
singleton
technic
in
SocketClient
to
have
at
most
one
socket
connection.

*NB:*  
Implementation
was
in
a
bid
to
resolve
disposed
connection
isssue
on
multiple
concurrent
socket
requests.
These
changes
are
temporary
while
we
work
on
implementing
a
SocketPool
to
requlate
the
number
of
sockets
that
can
be
opened
simultaneously.

###

*
*v1.1.2
**  
[Semi-Singleton ClientInitProxy]  
*1.*
Removed
a
semi
singleton
technic
in
SocketClient
to
have
at
most
one
socket
connection.

###

*
*v1.2.0
**  
[Socket Creation on GetAsync]  
*1.*
Changed
socket
creation
to
be
on
the
fly
during
transaction
request.

###

*
*v2.2.0
**  
[Namespaces]  
*1.*
Renamed
project
namespaces.
