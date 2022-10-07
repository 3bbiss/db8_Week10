drop database if exists bookclub2;
create database bookclub2;
use bookclub2;

create table person(
	id int not null auto_increment,
	firstname varchar(50),
	lastname varchar(50),
	email varchar(50),
	primary key (id)
);

insert into person (firstname, lastname, email) values('John', 'Smith', 'js@rm.com');
select * from person;

create table presentation(
	id int not null auto_increment,
	personid int,
	presentationdate datetime,
	booktitle varchar(50),
	bookauthor varchar(50),
	genre varchar(25),
	primary key (id),
	foreign key (personid) references person(id)
);