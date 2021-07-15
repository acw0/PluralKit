-- SCHEMA VERSION 16: <insert date> --
-- Add notes field for switches

alter table switches add column note text;

update info set schema_version = 16;