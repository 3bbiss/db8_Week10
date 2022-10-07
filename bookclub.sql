drop database if exists bookclub;
create database bookclub;
use bookclub;

create table person(
	id int not null auto_increment,
    firstname varchar(50),
    lastname varchar(50),
    email varchar(50),
    primary key (id)
);

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
