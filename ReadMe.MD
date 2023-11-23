standard minimal api

-----------------Cqrs------------------
add cqrs folder and create write / read repo

update program.cs to inject dependency of CustomersWrite/ReadRepository

fix the endpoints to use the read/write repositories. 
(CustomersCqrs.cs)

----------------CqrsTowardsMediatR------------
move add to add command
move update to update command
...
...


create customers folder, and commmands/queris sub folder
move commands to commands folder

move queris to qureis folder