
-- TO DO - SE E' PRESENTE LO SCRIPT - STOP EXECUTION
INSERT INTO `DbScriptMigration` (`MigrationId`, `MigrationName`, `MigrationDate`)
SELECT * FROM (SELECT UUID(),'002_create_categories_table',NOW()) AS tmp
WHERE NOT EXISTS (
    SELECT `MigrationName` FROM `DbScriptMigration` WHERE `MigrationName` = '002_create_categories_table'
) LIMIT 1;

CREATE TABLE IF NOT EXISTS `Categories` (
				`Id` INT NOT NULL AUTO_INCREMENT,
				`Name` varchar(150) NOT NULL,
				`Description` varchar(500) NOT NULL,
				`CreateDate` datetime NOT NULL,
			PRIMARY KEY (`Id`)
			) ENGINE=InnoDB;



INSERT INTO `Categories` (`Name`, `Description`, `CreateDate`)
SELECT * FROM (SELECT
    'Category 1'
           ,'Lorem ipsum dolor sit amet, consectetur adipiscing elit.'
           ,NOW()) AS tmp
WHERE NOT EXISTS (
    SELECT `Name` FROM `Categories` WHERE `Name` = 'Category 1'
) LIMIT 1;

INSERT INTO `Categories` (`Name`, `Description`, `CreateDate`)
SELECT * FROM (SELECT
    'Category 2'
           ,'Lorem ipsum dolor sit amet, consectetur adipiscing elit.'
           ,NOW()) AS tmp
WHERE NOT EXISTS (
    SELECT `Name` FROM `Categories` WHERE `Name` = 'Category 2'
) LIMIT 1;

ALTER TABLE `Posts`
  ADD COLUMN `CategoryId` INT,
  ADD FOREIGN KEY `FK_Posts_CategoryId`(`CategoryId`) REFERENCES `Categories`(`Id`);