USE composedemo;

CREATE TABLE composedemo.DemoItems(
    Id int auto_increment primary key,
    Title varchar(255) not null unique,
    Description varchar(255) not null
);

Insert INTO composedemo.DemoItems (Title, Description) VALUES 
('Link`s Awakening', 'A surreal Zelda adventure where you explore a dreamlike island to awaken the Wind Fish.'),
('Ikaruga', 'A bullet-hell shooter that challenges players with a unique polarity-switching mechanic for survival.'),
('Shadow of the Colossus', 'A haunting journey to topple towering colossi in a vast, desolate world.'),
('Deadly Premonition', 'A quirky, open-world detective thriller blending horror, mystery, and eccentric charm.'),
('Eternal Darkness', 'A psychological horror epic spanning centuries, where sanity is as fragile as life itself.');
