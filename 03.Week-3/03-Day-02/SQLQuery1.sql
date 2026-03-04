create database eventdb;
use eventdb;

create table userinfo(
emailid varchar(50) PRIMARY KEY,
username varchar(50) NOT NULL
check (len(username) between 1 and 50),
role varchar(50) NOT NULL
check(role IN ('Admin','Participant')),
password varchar(20) NOT NULL
check(len(password) between 8 and 20)
);


create table EventDetails(
EventId int primary key,
EventName varchar(50) not null
check(len(EventName) between 1 and 50),
EventCategory varchar(50) not null
check(len(EventCategory) between 1 and 50),
EventDate datetime not null,
Description varchar(100) ,
Status varchar(50)
check(Status IN ('Active' ,'In-Active'))
);


create table SpeakersDetails(
SpeakerId int primary key,
SpeakerName varchar(50) NOT NULL
check(len(SpeakerName )between 1 and 50)
);

Insert into SpeakersDetails values (1,'Sahithi');
Insert into SpeakersDetails values (2,'Sai');

Select * from SpeakersDetails;

select * from EventDetails;


create table SessionInfo(
SessionId int PRIMARY KEY,
EventId int NOT NULL ,
SessionTitle varchar(50) NOT NULL
check(len(SessionTitle) between 1 and 50),
SpeakerId int NOT NULL,
Description varchar(100) ,
SessionStart datetime NOT NULL,
SessionEnd datetime NOT NULL,
sessionURl varchar(100),
foreign key(EventId ) references EventDetails(EventId),
foreign key(SpeakerId) references SpeakersDetails(SpeakerId)
);


create table ParticipantEventDetails (
id int primary key,
ParticipantEmailId varchar(50) NOT NULL ,
EventId int NOT NULL,
SessionId int NOT NULL ,
IsAttended bit check(IsAttended IN (0 ,1)),
foreign key(ParticipantEmailId) references userinfo(EmailId),
foreign key (EventId) references EventDetails(EventId),
foreign key (SessionId) references SessionInfo(SessionId)
);

select * from userinfo;

Insert into userinfo values('sai@123','sahithi','Admin',987654321);

