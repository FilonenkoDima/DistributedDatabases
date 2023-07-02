EXEC sp_addlinkedserver @server = 'DESKTOP-B4L9B2O'

EXEC sp_addlinkedsrvlogin @rmtsrvname='DESKTOP-B4L9B2O',
                             @useself= 'False',
                             @locallogin='Employee',
                             @rmtuser='User',
                             @rmtpassword='';