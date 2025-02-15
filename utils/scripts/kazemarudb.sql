/*
	project:  kazemaru database script
	database: postgresql
*/

-- functions 
create or replace function table_updated()
returns trigger as $$
begin
	new.updated_at = now();
	return new;
end;
$$ language plpgsql;

create or replace function without_description()
returns varchar as $$
begin
	return 'without description';
end;
$$ language plpgsql;

-- utilities
create table if not exists tags (
	tag_id uuid primary key default(gen_random_uuid()),
	name varchar(50) not null,
	description varchar(50) default(without_description()),
	created_at timestamptz not null default(now()),
	updated_at timestamptz not null default(now())
);

-- users
create table if not exists users (
	user_id uuid primary key default(gen_random_uuid()),
	username varchar(50) unique not null,
	display_name varchar(50) unique not null,
	password varchar(255) not null,
	password_hint varchar(255) not null,
	created_at timestamptz not null default(now()),
	updated_at timestamptz not null default(now())
);

-- projects
create table if not exists projects_statuses (
	project_status_id serial primary key,
	name varchar(30) unique not null,
	description varchar(50) default(without_description()),
	name_color varchar(30) not null default('rgba(150, 150, 150, 0.9)'),
	background_color varchar(30) not null default('rgba(20, 20, 20, 0.9)'),
	created_at timestamptz not null default(now()),
	updated_at timestamptz not null default(now())
);

insert into projects_statuses (name, background_color)
values 
('Unstarted', 	'rgba(20, 20, 20, 0.9)'), 
('Starting',		'rgba(6, 40, 106, 0.9)'), 
('In progress', 'rgba(12, 58, 11, 0.9)'), 
('Ended', 			'rgba(48, 9, 9, 0.9)');

create table if not exists projects (
	project_id uuid primary key default(gen_random_uuid()),
	name varchar(50) unique not null,
	description text default(without_description()),
	status_id int references projects_statuses(project_status_id) not null default(1),
	owner_id uuid references users(user_id) not null,
	banner varchar(255),
	created_at timestamptz not null default(now()),
	updated_at timestamptz not null default(now())
);

create table if not exists projects_tags (
	tad_id uuid references tags(tag_id) not null unique,
	project_id uuid references projects(project_id) not null
);

create table if not exists projects_members (
	project_member_id serial primary key,
	project_id uuid references projects(project_id) not null,
	user_id uuid references users(user_id) not null,
	joined_at timestamptz not null default(now())
);

create table if not exists projects_blacklists (
	project_blacklist_id serial primary key,
	project_id uuid references projects(project_id) not null,
	user_id uuid references users(user_id) not null,
	created_at timestamptz not null default(now())
);

create table if not exists projects_shared_links (
	project_shared_link_id uuid primary key default(gen_random_uuid()),
	project_id uuid references projects(project_id) not null,
	value varchar(100) not null,
	created_at timestamptz not null default(now())
);

--- tasks
create table if not exists tasks_statuses (
	task_status_id serial primary key,
	name varchar(30) unique not null,
	description varchar(50) default(without_description()),
	name_color varchar(30) not null default('rgba(75, 75, 75, 0.9)'),
	background_color varchar(30) not null default('rgba(50, 50, 50, 0.9)'),
	created_at timestamptz not null default(now()),
	updated_at timestamptz not null default(now())
);

insert into tasks_statuses (name)
values ('Unstarted'), ('In progress'), ('Ended');

create table if not exists tasks (
	task_id uuid primary key default gen_random_uuid(),
	name varchar(50) not null,
	description text default(without_description()),
	status_id int references tasks_statuses(task_status_id) not null default(1),
	project_id uuid references projects(project_id) not null,
	created_at timestamptz not null default(now()),
	updated_at timestamptz not null default(now())
);

-- notes
create table if not exists notes (
	note_id uuid primary key default(gen_random_uuid()),
	title varchar(100) not null,
	content text not null,
	project_id uuid references projects(project_id),
	task_id uuid references tasks(task_id),
	created_at timestamptz not null default(now()),
	updated_at timestamptz not null default(now())
);

create table if not exists notes_tags (
	tag_id uuid references tags(tag_id) not null unique,
	note_id uuid references notes(note_id) not null
);

-- triggers
create or replace trigger trigger_before_tags_updated
before update on tags
for each row
execute function table_updated();

create or replace trigger trigger_before_users_updated
before update on users
for each row
execute function table_updated();

create or replace trigger trigger_before_projects_updated
before update on projects
for each row
execute function table_updated();

create or replace trigger trigger_before_projects_statuses_updated
before update on projects_statuses
for each row
execute function table_updated();

create or replace trigger trigger_before_tasks_updated
before update on tasks
for each row
execute function table_updated();

create or replace trigger trigger_before_tasks_statuses_updated
before update on tasks_statuses
for each row
execute function table_updated();

create or replace trigger trigger_before_notes_updated
before update on notes
for each row
execute function table_updated();
