USE master;
GO 


DROP DATABASE IF EXISTS Member;


CREATE DATABASE Member;
GO


USE Member;
GO


BEGIN TRANSACTION;


CREATE TABLE Member (

member_id INT IDENTITY(1,1),
last_name VARCHAR(50) NOT NULL,
first_name VARCHAR(50) NOT NULL,
email VARCHAR(30) NOT NULL,
phone_number VARCHAR(14) NOT NULL,
date_of_birth DATE,
email_reminder bit NOT NULL



CONSTRAINT pk_member PRIMARY KEY (member_id)
);

CREATE TABLE InterestGroup (
group_number INT IDENTITY(1,1),
name VARCHAR(50) NOT NULL,



CONSTRAINT pk_interestgroup PRIMARY KEY (group_number)
);

CREATE TABLE Meet_Event (
event_number INT IDENTITY (1,1),
description VARCHAR(50),
event_name VARCHAR(50) NOT NULL,
start_date_time DATETIME,
duration VARCHAR(50) NOT NULL,
group_number INT NOT NULL,


CONSTRAINT pk_meet_event PRIMARY KEY (event_number),
CONSTRAINT fk_group_id_foreign FOREIGN key (group_number) REFERENCES InterestGroup(group_number),
CONSTRAINT check_event CHECK (duration >= 30) 


);

CREATE TABLE member_group (
member_id INT NOT NULL, 
group_number INT NOT NULL, 

CONSTRAINT pk_member_group PRIMARY KEY (member_id, group_number),
CONSTRAINT fk_member_group_member FOREIGN KEY (member_id) REFERENCES Member(member_id),
CONSTRAINT fk_member_group_group FOREIGN KEY (group_number) REFERENCES InterestGroup(group_number)
);

CREATE TABLE member_event (
member_id INT NOT NULL,
event_number INT NOT NULL,

CONSTRAINT pk_member_event PRIMARY KEY (member_id, event_number),
CONSTRAINT fk_member_event_member FOREIGN KEY (member_id) REFERENCES Member(member_id),
CONSTRAINT fk_member_event_event FOREIGN KEY (event_number) REFERENCES Meet_Event(event_number)

);




COMMIT;


INSERT INTO Member (last_name, first_name, email, phone_number, date_of_birth, email_reminder)
VALUES('Bush', 'Sophia', 'sophiabush@gmail.com', '430-403-2010', '06/19/1989', 0),
('Burton', 'Hilary', 'hilaryburton2929@yahoo.com', '560-890-4323', '1/5/1987', 0),
('Murray', 'Chad', 'chadmurray58674@yahoo.com', '232-293-9593', '1/9/1990', 0),
('Lenz', 'Bethany Joy', 'bethanyjoylenz39858@yahoo.com', '430-203-5930', '1/6/1990', 0),
('Laffery', 'James', 'jamesl4@yahoo.com', '430-949-1201', '5/30/1980', 0),
('Norris', 'Lee', 'norrislee09@yahoo.com', '430-202-1202', '7/30/1989', 0),
('Tanner', 'Antwon', 'antwontanner@gmail.com', '430-302-3031', '8/19/1986', 0),
('Johannson', 'Paul', 'pauljohannson202@yahoo.com', '430-908-9900', '5/14/1989', 0);


INSERT INTO InterestGroup (name)
VALUES ('Artist'), ('Athlete'), ('Tutor')

INSERT INTO Meet_Event (event_name, description, start_date_time, duration, group_number)
VALUES ('The RiverCourt Basketball Game', 'This is an 8 vs 8 basketball game', GETDATE(), '80', 2),
('Concert at Tric', 'Three bands play for 3 hours starting at 6pm', GETDATE(), '80', 1),
('Tutoring at Tree Hill High', 'Open tutoring event for students', GETDATE(), '90', 3),
('Painting at the Beach', 'Tree hill painting event', GETDATE(), '90', 1),
('Study at Karens Cafe', 'Open study session and free coffee at the cafe', GETDATE(), '90', 3);

SELECT * FROM Member_event

--INSERT INTO member_event(member_id, event_number)
--VALUES(1,1), (2,1), (3,2), (4,3), (5,2), (6,2), (7,2), (8,4);


INSERT INTO member_group(member_id, group_number)
VALUES(1,1), (1,2), (2,2), (2,3), (3,1), (4,3), (5,1), (6,3)

select * from Member