CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS contractors(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        name VARCHAR(255)
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS companies(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        name VARCHAR(255)
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS jobs(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        companyId INT NOT NULL,
        contractorId INT NOT Null FOREIGN KEY(companiesId) REFERENCES companies(id) ON DELETE CASCADE,
        FOREIGN KEY (contractorId) REFERENCES contractor(id) ON DELETE CASCADE
    )