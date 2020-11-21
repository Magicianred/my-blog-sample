
-- TO DO - SE E' PRESENTE LO SCRIPT - STOP EXECUTION
INSERT INTO `DbScriptMigration` (`MigrationId`, `MigrationName`, `MigrationDate`)
SELECT * FROM (SELECT UUID(),'004_add_col_author_to_posts_table',NOW()) AS tmp
WHERE NOT EXISTS (
    SELECT `MigrationName` FROM `DbScriptMigration` WHERE `MigrationName` = '004_add_col_author_to_posts_table'
) LIMIT 1;


-- insert column Author to table Posts
ALTER TABLE `Posts`
  ADD COLUMN `Author` VARCHAR(200) NULL;

  
-- valorize column Author where is not set (possible warning who prevent to update without filter Key column)
 UPDATE `Posts` SET Author = 'Tom' WHERE Author IS NULL;