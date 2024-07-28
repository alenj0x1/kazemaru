/*
	Kazemaru database script
	Database: PostgreSQL
*/

create table Tag (
	tagId uuid primary key default gen_random_uuid(),
	name varchar(50) not null,
	description varchar(50),
	createdAt timestamptz default now() not null,
	updatedAt timestamptz default now() not null
);

create table ProjectStatus (
	projectStatusId serial primary key,
	name varchar(30) unique not null,
	description varchar(50),
	nameColor varchar(30) default 'rgba(75, 75, 75, 0.9)' not null,
	backgroundColor varchar(30) default 'rgba(50, 50, 50, 0.9)' not null
);

insert into ProjectStatus (name)
values ('Unstarted'), ('Starting'), ('In progress'), ('Ended');

create table Project (
	projectId uuid primary key default gen_random_uuid(),
	name varchar(50) unique not null,
	description text default 'without description.',
	statusId int references ProjectStatus(projectStatusId) default 1 not null,
	createdAt timestamptz default now() not null,
	updatedAt timestamptz default now() not null
);

create table ProjectTag(
	tagId uuid references Tag(tagId) not null unique,
	projectId uuid references Project(projectId) not null
);

create table TaskStatus (
	taskStatusId serial primary key,
	name varchar(30) unique not null,
	description varchar(50),
	nameColor varchar(30) default 'rgba(75, 75, 75, 0.9)' not null,
	backgroundColor varchar(30) default 'rgba(50, 50, 50, 0.9)' not null
);

insert into TaskStatus (name)
values ('Unstarted'), ('In progress'), ('Ended');

create table Task (
	taskId uuid primary key default gen_random_uuid(),
	name varchar(50) not null,
	description text default 'without description.',
	statusId int references TaskStatus(taskStatusId) default 1 not null,
	projectId uuid references Project(projectId) not null,
	createdAt timestamptz default now() not null,
	updatedAt timestamptz default now() not null
);

create table Note (
	noteId uuid primary key default gen_random_uuid(),
	title varchar(100) not null,
	content text not null,
	projectId uuid references Project(projectId),
	taskId uuid references Task(taskId),
	createdAt timestamptz default now() not null,
	updatedAt timestamptz default now() not null
);

create table NoteTag(
	tagId uuid references Tag(tagId) not null unique,
	noteId uuid references Note(noteId) not null
);
