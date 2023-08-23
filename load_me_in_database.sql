/*
BAKING ZTZBX SQL SCRIPT
*/

CREATE TABLE economyonserver (
    currency_on_server varchar(255) NOT NULL,
    PRIMARY KEY (currency_on_server),
    FOREIGN KEY (currency_on_server) REFERENCES itemsmetadata(`name`)
) ENGINE=InnoDB;


CREATE TABLE economyplayer (
    username varchar(50) NOT NULL,
    money_on_bank int NOT NULL DEFAULT 0,
    PRIMARY KEY (username),
    FOREIGN KEY (username) REFERENCES players(username)
) ENGINE=InnoDB;


/* Lei Currency RO */
INSERT INTO `itemsmetadata` (`name`, `image`, `descriptiontitle`, `description`, `type`, `unit`, `weight`) VALUES (
 'Lei',
 'Lei.png',
 'Lei Romanesti',
 'Numerarul este mijloc legal de plată monedă sau monede care poate fi folosit pentru a schimba bunuri, datorii sau servicii',
 'money', 'UNT', '5'
);


/* USD Currency ING */
INSERT INTO `itemsmetadata` (`name`, `image`, `descriptiontitle`, `description`, `type`, `unit`, `weight`) VALUES (
 'USD',
 'USD.png',
 'USD American',
 'Cash is legal tender—currency or coins—that can be used to exchange goods, debt, or services',
 'money', 'UNT', '5'
);

/* Default curreny set */
INSERT INTO `economyonserver` (`currency_on_server`) VALUES ('Lei'); 