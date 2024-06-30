/*
	Kazemaru database script
	Database: PostgreSQL
*/

create database kazemarudb;

create table ProjectStatus (
	statusId serial primary key,
	name varchar(30) unique not null,
	content varchar(50)
);

insert into ProjectStatus (name)
values ('unstarted'), ('starting'), ('in_progress'), ('ended');

create table Project (
	projectId uuid primary key default gen_random_uuid(),
	name varchar(50) unique not null,
	description text default 'without description.',
	status int references ProjectStatus(statusId) default 1,
	createdAt timestamp default now(),
	updatedAt timestamp default now()
);

create table ProjectTag (
	projectTagId uuid primary key default gen_random_uuid(),
	projectId uuid not null,
	name varchar(30) unique not null
);

create table TaskStatus (
	statusId serial primary key,
	name varchar(30) unique not null
);

insert into TaskStatus (name)
values ('unstarted'), ('in_progress'), ('ended');

create table Task (
	taskId uuid primary key default gen_random_uuid(),
	name varchar(50) not null,
	description text default 'without description.',
	status int references TaskStatus(statusId),
	projectId uuid references Project(projectId) not null,
	createdAt timestamp default now(),
	updatedAt timestamp default now()
);

create table Note (
	noteId uuid primary key default gen_random_uuid(),
	title varchar(100) not null,
	content text not null,
	projectId uuid references Project(projectId),
	taskId uuid references Task(taskId),
	createdAt timestamp default now(),
	updatedAt timestamp default now()
);

create table NoteTag (
	noteTagId uuid primary key default gen_random_uuid(),
	noteId uuid not null,
	name varchar(30) unique not null
);
