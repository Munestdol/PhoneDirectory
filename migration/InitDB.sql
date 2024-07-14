CREATE TABLE Departments (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    parent_id INT,
    FOREIGN KEY (parent_id) REFERENCES Departments(id) ON DELETE SET NULL
);

CREATE TABLE Employees (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    position VARCHAR(100) NOT NULL,
    phone_number VARCHAR(15),
    department_id INT,
    FOREIGN KEY (department_id) REFERENCES Departments(id) ON DELETE CASCADE
);