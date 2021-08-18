create database Spotify;

------creating a database------

use Spotify;

create table userTable(
userid int primary key,
userName varchar(100));

------creating UserTable-------

select * from userTable;

insert into userTable values (1,'vivek'),(2,'pavani'),(3,'Aditya'),(4,'harish');

create table playlist(
playlistId int primary key,
userid int foreign key references userTable(userid));

insert into playlist values (1,2),(2,1),(3,3),(4,2);
select * from playlist;
delete playlist;

-----creating playlist table--------

create table playlist(
playlistId int primary key);

alter table playlist
add playlistName varchar(100); 


alter table userTable
add playlistId int; 

alter table userTable
add foreign key (playlistId) references playlist(playlistId);

insert into playlist values (11),(21),(13);
update playlist set playlistName = 'Playlist1' where playlistId = 11;

select * from playlist;

select * from userTable;

insert into userTable (userid,playlistId) values (1,11),(2,21),(3,13),(4,21);

update userTable set playlistId = 13 where userid = 1;

update userTable set playlistId = 21 where userid = 2;

update userTable set playlistId = 21 where userid = 4;

update userTable set playlistId = 11 where userid = 3;

--------creating track table-------

create table track(
trackId int primary key,
userid int foreign key references userTable(userid),
playlistId int foreign key references playlist(playlistId));

insert into track values (29,1,13),(17,2,21),(45,3,11),(32,4,21);

select * from track;

select userTable.userid,userTable.userName,track.playlistId,track.trackId from userTable LEFT JOIN track on userTable.userid = track.userid where track.trackId = 32;

select userTable.userid,userTable.userName,track.playlistId,track.trackId from userTable LEFT JOIN track on userTable.userid = track.userid where track.playlistId = 11;