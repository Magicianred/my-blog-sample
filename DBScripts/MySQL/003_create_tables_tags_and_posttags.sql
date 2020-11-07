
-- TO DO - SE E' PRESENTE LO SCRIPT - STOP EXECUTION
INSERT INTO `DbScriptMigration` (`MigrationId`, `MigrationName`, `MigrationDate`)
SELECT * FROM (SELECT UUID(),'003_create_tables_tags_and_posttags',NOW()) AS tmp
WHERE NOT EXISTS (
    SELECT `MigrationName` FROM `DbScriptMigration` WHERE `MigrationName` = '002_create_categories_table'
) LIMIT 1;

CREATE TABLE IF NOT EXISTS `Tags` (
				`Id` INT NOT NULL AUTO_INCREMENT,
				`Name` varchar(150) NOT NULL,
				`Description` varchar(500) NOT NULL,
				`CreateDate` datetime NOT NULL,
			PRIMARY KEY (`Id`)
			) ENGINE=InnoDB;


-- INSERT some example data
INSERT INTO `Tags` (`Name`, `Description`, `CreateDate`)
SELECT * FROM (SELECT
    'Tag 1'
           ,'Description for tag 1'
           ,NOW()) AS tmp
WHERE NOT EXISTS (
    SELECT `Name` FROM `Tags` WHERE `Name` = 'Tag 1'
) LIMIT 1;

INSERT INTO `Tags` (`Name`, `Description`, `CreateDate`)
SELECT * FROM (SELECT
    'Tag 2'
           ,'Description for tag 2'
           ,NOW()) AS tmp
WHERE NOT EXISTS (
    SELECT `Name` FROM `Tags` WHERE `Name` = 'Tag 2'
) LIMIT 1;

CREATE TABLE IF NOT EXISTS `PostTags` (
				`PostId` INT NOT NULL,
				`TagId` INT NOT NULL,
			PRIMARY KEY (`PostId`, `TagId`)
			) ENGINE=InnoDB;


INSERT INTO `PostTags` (`PostId`, `TagId`)
VALUES (1, 1), (2, 2), (3, 1), (4, 2);
