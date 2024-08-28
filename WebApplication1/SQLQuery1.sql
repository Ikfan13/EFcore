alter table employee with check add constraint fk_emp_dept foreign key (Departmentid) references Department(id)

alter table employee check constraint fk_emp_dept;