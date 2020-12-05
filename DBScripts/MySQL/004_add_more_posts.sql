
-- TO DO - SE E' PRESENTE LO SCRIPT - STOP EXECUTION
INSERT INTO `DbScriptMigration` (`MigrationId`, `MigrationName`, `MigrationDate`)
SELECT * FROM (SELECT UUID(),'004_add_more_posts',NOW()) AS tmp
WHERE NOT EXISTS (
    SELECT `MigrationName` FROM `DbScriptMigration` WHERE `MigrationName` = '004_add_more_posts'
) LIMIT 1;




INSERT INTO `Posts` (`Title`, `Text`, `CreateDate`)
SELECT * FROM (SELECT
    'Forth post of the blog'
           ,'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut quis enim eu augue tincidunt tincidunt. Nam luctus pharetra tortor, sit amet sodales odio bibendum non. Nulla imperdiet tempor metus, sit amet posuere justo laoreet nec. Nullam vehicula commodo posuere. Ut elementum, purus id posuere porttitor, massa purus tristique sapien, nec sollicitudin massa lectus ac erat. Nunc id tortor quis leo placerat accumsan nec scelerisque ligula. Vivamus in efficitur felis. Cras tincidunt eleifend leo ut volutpat. Sed ut ligula eu risus pretium volutpat sit amet vel lorem. Aliquam gravida blandit risus non laoreet.

Praesent felis velit, interdum ac laoreet luctus, finibus vel lorem. In vitae dolor ipsum. Quisque pretium eu ex in egestas. Nam imperdiet in diam eu maximus. Nulla tristique magna velit, vitae scelerisque augue facilisis id. Nulla in ultricies ex, nec lobortis felis. Nam nec vestibulum libero, ut laoreet tellus. Pellentesque ut metus sed nulla fermentum consequat at nec ligula. Donec pretium nisi rhoncus elit tincidunt, eu euismod ligula semper.

In at enim sit amet magna luctus sagittis et quis lacus. In blandit enim risus, eu pharetra nibh pharetra id. Nullam diam augue, fermentum eget aliquam sed, ornare sit amet dolor. Fusce fringilla vestibulum aliquam. Curabitur id laoreet lectus. Proin pretium nunc vel sem bibendum fringilla. Aliquam rhoncus neque enim, pellentesque consequat turpis gravida in. Ut at massa non augue fringilla pellentesque. Mauris consectetur pellentesque mauris molestie ullamcorper. Vivamus at nisi sed turpis cursus porttitor a sed enim. Quisque nec lorem ultrices, vestibulum sapien et, sollicitudin arcu. Donec augue risus, eleifend a tempus eu, hendrerit a quam.

Sed ex arcu, fringilla at molestie sit amet, accumsan id odio. Sed ut est orci. Suspendisse convallis mauris in fringilla facilisis. Nulla sit amet orci sed elit sollicitudin placerat. Pellentesque blandit, eros ut blandit volutpat, elit diam pulvinar tellus, vel vulputate urna augue at nisi. Suspendisse id odio quis risus dignissim elementum. Suspendisse vitae interdum dui, id euismod lacus. Mauris sit amet nisi nec diam fringilla lacinia. Nulla mauris nulla, vestibulum a convallis a, imperdiet nec neque. Phasellus aliquet sollicitudin mauris, id congue est varius sit amet. Etiam imperdiet mauris id dui iaculis commodo. Vivamus at nisl ligula. Cras iaculis varius orci, non congue nunc commodo ut.

Donec a justo porttitor, placerat ante sed, ullamcorper quam. Aliquam dapibus velit leo, at fermentum libero iaculis eget. Nullam eu mattis lorem, ac vulputate libero. Duis quis dui eget leo condimentum eleifend a et nisi. Suspendisse lorem tortor, pharetra vitae ornare vel, ullamcorper eu odio. Sed suscipit iaculis massa eu varius. Proin augue quam, ullamcorper quis velit sed, ultrices condimentum orci. Vivamus nisi leo, convallis fermentum dolor quis, suscipit iaculis nisi.'
           ,NOW()) AS tmp
WHERE NOT EXISTS (
    SELECT `Title` FROM `Posts` WHERE `Title` = 'Forth post of the blog'
) LIMIT 1;

INSERT INTO `Posts` (`Title`, `Text`, `CreateDate`)
SELECT * FROM (SELECT
    'Fifth post of the blog'
           ,'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut quis enim eu augue tincidunt tincidunt. Nam luctus pharetra tortor, sit amet sodales odio bibendum non. Nulla imperdiet tempor metus, sit amet posuere justo laoreet nec. Nullam vehicula commodo posuere. Ut elementum, purus id posuere porttitor, massa purus tristique sapien, nec sollicitudin massa lectus ac erat. Nunc id tortor quis leo placerat accumsan nec scelerisque ligula. Vivamus in efficitur felis. Cras tincidunt eleifend leo ut volutpat. Sed ut ligula eu risus pretium volutpat sit amet vel lorem. Aliquam gravida blandit risus non laoreet.

Praesent felis velit, interdum ac laoreet luctus, finibus vel lorem. In vitae dolor ipsum. Quisque pretium eu ex in egestas. Nam imperdiet in diam eu maximus. Nulla tristique magna velit, vitae scelerisque augue facilisis id. Nulla in ultricies ex, nec lobortis felis. Nam nec vestibulum libero, ut laoreet tellus. Pellentesque ut metus sed nulla fermentum consequat at nec ligula. Donec pretium nisi rhoncus elit tincidunt, eu euismod ligula semper.

In at enim sit amet magna luctus sagittis et quis lacus. In blandit enim risus, eu pharetra nibh pharetra id. Nullam diam augue, fermentum eget aliquam sed, ornare sit amet dolor. Fusce fringilla vestibulum aliquam. Curabitur id laoreet lectus. Proin pretium nunc vel sem bibendum fringilla. Aliquam rhoncus neque enim, pellentesque consequat turpis gravida in. Ut at massa non augue fringilla pellentesque. Mauris consectetur pellentesque mauris molestie ullamcorper. Vivamus at nisi sed turpis cursus porttitor a sed enim. Quisque nec lorem ultrices, vestibulum sapien et, sollicitudin arcu. Donec augue risus, eleifend a tempus eu, hendrerit a quam.

Sed ex arcu, fringilla at molestie sit amet, accumsan id odio. Sed ut est orci. Suspendisse convallis mauris in fringilla facilisis. Nulla sit amet orci sed elit sollicitudin placerat. Pellentesque blandit, eros ut blandit volutpat, elit diam pulvinar tellus, vel vulputate urna augue at nisi. Suspendisse id odio quis risus dignissim elementum. Suspendisse vitae interdum dui, id euismod lacus. Mauris sit amet nisi nec diam fringilla lacinia. Nulla mauris nulla, vestibulum a convallis a, imperdiet nec neque. Phasellus aliquet sollicitudin mauris, id congue est varius sit amet. Etiam imperdiet mauris id dui iaculis commodo. Vivamus at nisl ligula. Cras iaculis varius orci, non congue nunc commodo ut.

Donec a justo porttitor, placerat ante sed, ullamcorper quam. Aliquam dapibus velit leo, at fermentum libero iaculis eget. Nullam eu mattis lorem, ac vulputate libero. Duis quis dui eget leo condimentum eleifend a et nisi. Suspendisse lorem tortor, pharetra vitae ornare vel, ullamcorper eu odio. Sed suscipit iaculis massa eu varius. Proin augue quam, ullamcorper quis velit sed, ultrices condimentum orci. Vivamus nisi leo, convallis fermentum dolor quis, suscipit iaculis nisi.'
           ,NOW()) AS tmp
WHERE NOT EXISTS (
    SELECT `Title` FROM `Posts` WHERE `Title` = 'Fifth post of the blog'
) LIMIT 1;

INSERT INTO `Posts` (`Title`, `Text`, `CreateDate`)
SELECT * FROM (SELECT
    'Sixth post of the blog'
           ,'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut quis enim eu augue tincidunt tincidunt. Nam luctus pharetra tortor, sit amet sodales odio bibendum non. Nulla imperdiet tempor metus, sit amet posuere justo laoreet nec. Nullam vehicula commodo posuere. Ut elementum, purus id posuere porttitor, massa purus tristique sapien, nec sollicitudin massa lectus ac erat. Nunc id tortor quis leo placerat accumsan nec scelerisque ligula. Vivamus in efficitur felis. Cras tincidunt eleifend leo ut volutpat. Sed ut ligula eu risus pretium volutpat sit amet vel lorem. Aliquam gravida blandit risus non laoreet.

Praesent felis velit, interdum ac laoreet luctus, finibus vel lorem. In vitae dolor ipsum. Quisque pretium eu ex in egestas. Nam imperdiet in diam eu maximus. Nulla tristique magna velit, vitae scelerisque augue facilisis id. Nulla in ultricies ex, nec lobortis felis. Nam nec vestibulum libero, ut laoreet tellus. Pellentesque ut metus sed nulla fermentum consequat at nec ligula. Donec pretium nisi rhoncus elit tincidunt, eu euismod ligula semper.

In at enim sit amet magna luctus sagittis et quis lacus. In blandit enim risus, eu pharetra nibh pharetra id. Nullam diam augue, fermentum eget aliquam sed, ornare sit amet dolor. Fusce fringilla vestibulum aliquam. Curabitur id laoreet lectus. Proin pretium nunc vel sem bibendum fringilla. Aliquam rhoncus neque enim, pellentesque consequat turpis gravida in. Ut at massa non augue fringilla pellentesque. Mauris consectetur pellentesque mauris molestie ullamcorper. Vivamus at nisi sed turpis cursus porttitor a sed enim. Quisque nec lorem ultrices, vestibulum sapien et, sollicitudin arcu. Donec augue risus, eleifend a tempus eu, hendrerit a quam.

Sed ex arcu, fringilla at molestie sit amet, accumsan id odio. Sed ut est orci. Suspendisse convallis mauris in fringilla facilisis. Nulla sit amet orci sed elit sollicitudin placerat. Pellentesque blandit, eros ut blandit volutpat, elit diam pulvinar tellus, vel vulputate urna augue at nisi. Suspendisse id odio quis risus dignissim elementum. Suspendisse vitae interdum dui, id euismod lacus. Mauris sit amet nisi nec diam fringilla lacinia. Nulla mauris nulla, vestibulum a convallis a, imperdiet nec neque. Phasellus aliquet sollicitudin mauris, id congue est varius sit amet. Etiam imperdiet mauris id dui iaculis commodo. Vivamus at nisl ligula. Cras iaculis varius orci, non congue nunc commodo ut.

Donec a justo porttitor, placerat ante sed, ullamcorper quam. Aliquam dapibus velit leo, at fermentum libero iaculis eget. Nullam eu mattis lorem, ac vulputate libero. Duis quis dui eget leo condimentum eleifend a et nisi. Suspendisse lorem tortor, pharetra vitae ornare vel, ullamcorper eu odio. Sed suscipit iaculis massa eu varius. Proin augue quam, ullamcorper quis velit sed, ultrices condimentum orci. Vivamus nisi leo, convallis fermentum dolor quis, suscipit iaculis nisi.'
           ,NOW()) AS tmp
WHERE NOT EXISTS (
    SELECT `Title` FROM `Posts` WHERE `Title` = 'Sixth post of the blog'
) LIMIT 1;

INSERT INTO `Posts` (`Title`, `Text`, `CreateDate`)
SELECT * FROM (SELECT
    'Seventh post of the blog'
           ,'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut quis enim eu augue tincidunt tincidunt. Nam luctus pharetra tortor, sit amet sodales odio bibendum non. Nulla imperdiet tempor metus, sit amet posuere justo laoreet nec. Nullam vehicula commodo posuere. Ut elementum, purus id posuere porttitor, massa purus tristique sapien, nec sollicitudin massa lectus ac erat. Nunc id tortor quis leo placerat accumsan nec scelerisque ligula. Vivamus in efficitur felis. Cras tincidunt eleifend leo ut volutpat. Sed ut ligula eu risus pretium volutpat sit amet vel lorem. Aliquam gravida blandit risus non laoreet.

Praesent felis velit, interdum ac laoreet luctus, finibus vel lorem. In vitae dolor ipsum. Quisque pretium eu ex in egestas. Nam imperdiet in diam eu maximus. Nulla tristique magna velit, vitae scelerisque augue facilisis id. Nulla in ultricies ex, nec lobortis felis. Nam nec vestibulum libero, ut laoreet tellus. Pellentesque ut metus sed nulla fermentum consequat at nec ligula. Donec pretium nisi rhoncus elit tincidunt, eu euismod ligula semper.

In at enim sit amet magna luctus sagittis et quis lacus. In blandit enim risus, eu pharetra nibh pharetra id. Nullam diam augue, fermentum eget aliquam sed, ornare sit amet dolor. Fusce fringilla vestibulum aliquam. Curabitur id laoreet lectus. Proin pretium nunc vel sem bibendum fringilla. Aliquam rhoncus neque enim, pellentesque consequat turpis gravida in. Ut at massa non augue fringilla pellentesque. Mauris consectetur pellentesque mauris molestie ullamcorper. Vivamus at nisi sed turpis cursus porttitor a sed enim. Quisque nec lorem ultrices, vestibulum sapien et, sollicitudin arcu. Donec augue risus, eleifend a tempus eu, hendrerit a quam.

Sed ex arcu, fringilla at molestie sit amet, accumsan id odio. Sed ut est orci. Suspendisse convallis mauris in fringilla facilisis. Nulla sit amet orci sed elit sollicitudin placerat. Pellentesque blandit, eros ut blandit volutpat, elit diam pulvinar tellus, vel vulputate urna augue at nisi. Suspendisse id odio quis risus dignissim elementum. Suspendisse vitae interdum dui, id euismod lacus. Mauris sit amet nisi nec diam fringilla lacinia. Nulla mauris nulla, vestibulum a convallis a, imperdiet nec neque. Phasellus aliquet sollicitudin mauris, id congue est varius sit amet. Etiam imperdiet mauris id dui iaculis commodo. Vivamus at nisl ligula. Cras iaculis varius orci, non congue nunc commodo ut.

Donec a justo porttitor, placerat ante sed, ullamcorper quam. Aliquam dapibus velit leo, at fermentum libero iaculis eget. Nullam eu mattis lorem, ac vulputate libero. Duis quis dui eget leo condimentum eleifend a et nisi. Suspendisse lorem tortor, pharetra vitae ornare vel, ullamcorper eu odio. Sed suscipit iaculis massa eu varius. Proin augue quam, ullamcorper quis velit sed, ultrices condimentum orci. Vivamus nisi leo, convallis fermentum dolor quis, suscipit iaculis nisi.'
           ,NOW()) AS tmp
WHERE NOT EXISTS (
    SELECT `Title` FROM `Posts` WHERE `Title` = 'Seventh post of the blog'
) LIMIT 1;

INSERT INTO `Posts` (`Title`, `Text`, `CreateDate`)
SELECT * FROM (SELECT
    'Eighth post of the blog'
           ,'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut quis enim eu augue tincidunt tincidunt. Nam luctus pharetra tortor, sit amet sodales odio bibendum non. Nulla imperdiet tempor metus, sit amet posuere justo laoreet nec. Nullam vehicula commodo posuere. Ut elementum, purus id posuere porttitor, massa purus tristique sapien, nec sollicitudin massa lectus ac erat. Nunc id tortor quis leo placerat accumsan nec scelerisque ligula. Vivamus in efficitur felis. Cras tincidunt eleifend leo ut volutpat. Sed ut ligula eu risus pretium volutpat sit amet vel lorem. Aliquam gravida blandit risus non laoreet.

Praesent felis velit, interdum ac laoreet luctus, finibus vel lorem. In vitae dolor ipsum. Quisque pretium eu ex in egestas. Nam imperdiet in diam eu maximus. Nulla tristique magna velit, vitae scelerisque augue facilisis id. Nulla in ultricies ex, nec lobortis felis. Nam nec vestibulum libero, ut laoreet tellus. Pellentesque ut metus sed nulla fermentum consequat at nec ligula. Donec pretium nisi rhoncus elit tincidunt, eu euismod ligula semper.

In at enim sit amet magna luctus sagittis et quis lacus. In blandit enim risus, eu pharetra nibh pharetra id. Nullam diam augue, fermentum eget aliquam sed, ornare sit amet dolor. Fusce fringilla vestibulum aliquam. Curabitur id laoreet lectus. Proin pretium nunc vel sem bibendum fringilla. Aliquam rhoncus neque enim, pellentesque consequat turpis gravida in. Ut at massa non augue fringilla pellentesque. Mauris consectetur pellentesque mauris molestie ullamcorper. Vivamus at nisi sed turpis cursus porttitor a sed enim. Quisque nec lorem ultrices, vestibulum sapien et, sollicitudin arcu. Donec augue risus, eleifend a tempus eu, hendrerit a quam.

Sed ex arcu, fringilla at molestie sit amet, accumsan id odio. Sed ut est orci. Suspendisse convallis mauris in fringilla facilisis. Nulla sit amet orci sed elit sollicitudin placerat. Pellentesque blandit, eros ut blandit volutpat, elit diam pulvinar tellus, vel vulputate urna augue at nisi. Suspendisse id odio quis risus dignissim elementum. Suspendisse vitae interdum dui, id euismod lacus. Mauris sit amet nisi nec diam fringilla lacinia. Nulla mauris nulla, vestibulum a convallis a, imperdiet nec neque. Phasellus aliquet sollicitudin mauris, id congue est varius sit amet. Etiam imperdiet mauris id dui iaculis commodo. Vivamus at nisl ligula. Cras iaculis varius orci, non congue nunc commodo ut.

Donec a justo porttitor, placerat ante sed, ullamcorper quam. Aliquam dapibus velit leo, at fermentum libero iaculis eget. Nullam eu mattis lorem, ac vulputate libero. Duis quis dui eget leo condimentum eleifend a et nisi. Suspendisse lorem tortor, pharetra vitae ornare vel, ullamcorper eu odio. Sed suscipit iaculis massa eu varius. Proin augue quam, ullamcorper quis velit sed, ultrices condimentum orci. Vivamus nisi leo, convallis fermentum dolor quis, suscipit iaculis nisi.'
           ,NOW()) AS tmp
WHERE NOT EXISTS (
    SELECT `Title` FROM `Posts` WHERE `Title` = 'Eighth post of the blog'
) LIMIT 1;


-- -- Update some post set CategoryId = 1
--  UPDATE `Posts` SET CategoryId = 1 WHERE id IN (select case  when MOD(id, 2) = 1 then id else 0 end FROM `Posts`);


-- -- Update some post set CategoryId = 2
--  UPDATE `Posts` SET CategoryId = 2 WHERE id IN (select case  when MOD(id, 2) = 0 then id else 0 end FROM `Posts`)


 
 
-- -- valorize column Author where is not set (possible warning who prevent to update without filter Key column)
--  UPDATE `Posts` SET Author = 'Tom' WHERE Author IS NULL AND id IN (select case  when MOD(id, 2) = 1 then id else 0 end FROM `Posts`)
--  UPDATE `Posts` SET Author = 'Jim' WHERE Author IS NULL AND id IN (select case  when MOD(id, 2) = 0 then id else 0 end FROM `Posts`)

 
-- -- change values based on ids on your database
-- INSERT INTO `PostTags` (`PostId`, `TagId`)
-- VALUES (4, 1), (5, 2), (6, 1), (7, 2), (8, 1);