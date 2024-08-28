alter table employee with check add constraint fk_emp_dept foreign key (departmentid) references department(Id)

alter table employee check constraint fk_emp_dept