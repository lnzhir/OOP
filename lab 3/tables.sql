
CREATE TABLE public."PlayerCharacters"
(
    id biserial primary key,
    name varchar(255) NOT NULL,
    health integer NOT NULL,
    level integer,
    experience integer
)


CREATE TABLE public."NonPlayerCharacters"
(
    id biserial primary key,
    name varchar(255) NOT NULL,
    health integer NOT NULL,
    role varchar(255),
    attitude integer,
)



create table public."Levels" (
	id bigserial primary key,
	name varchar(64),
	pc_id bigint references "PlayerCharacters"(id)
);


create table public."NPCSets" (
	level_id bigserial references "Levels"(id),
	npc_id bigint not null references "NonPlayerCharacters"(id),
	
	PRIMARY KEY (level_id, npc_id)
);