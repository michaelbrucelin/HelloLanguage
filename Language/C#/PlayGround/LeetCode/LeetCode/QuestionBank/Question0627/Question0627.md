#### [627\. ����Ա�](https://leetcode.cn/problems/swap-salary/)

�Ѷȣ���

SQL�ܹ�
```sql
Create table If Not Exists Salary (id int, name varchar(100), sex char(1), salary int)
Truncate table Salary
insert into Salary (id, name, sex, salary) values ('1', 'A', 'm', '2500')
insert into Salary (id, name, sex, salary) values ('2', 'B', 'f', '1500')
insert into Salary (id, name, sex, salary) values ('3', 'C', 'm', '5500')
insert into Salary (id, name, sex, salary) values ('4', 'D', 'f', '500')
```

`Salary` ��

```
+-------------+----------+
| Column Name | Type     |
+-------------+----------+
| id          | int      |
| name        | varchar  |
| sex         | ENUM     |
| salary      | int      |
+-------------+----------+
id ��������������
sex ��һ�е�ֵ�� ENUM ���ͣ�ֻ�ܴ� ('m', 'f') ��ȡ��
���������˾��Ա����Ϣ��
```

�����дһ�� SQL ��ѯ���������е� `'f'` �� `'m'` ������������ `'f'` ��Ϊ `'m'` ����֮��Ȼ������ʹ�� **���� update ���** ���Ҳ������м���ʱ��

ע�⣬������ʹ��һ�� update ��䣬�� **����** ʹ�� select ��䡣

��ѯ�����������ʾ��

**ʾ�� 1:**

```
���룺
Salary ��
+----+------+-----+--------+
| id | name | sex | salary |
+----+------+-----+--------+
| 1  | A    | m   | 2500   |
| 2  | B    | f   | 1500   |
| 3  | C    | m   | 5500   |
| 4  | D    | f   | 500    |
+----+------+-----+--------+
�����
+----+------+-----+--------+
| id | name | sex | salary |
+----+------+-----+--------+
| 1  | A    | f   | 2500   |
| 2  | B    | m   | 1500   |
| 3  | C    | f   | 5500   |
| 4  | D    | m   | 500    |
+----+------+-----+--------+
���ͣ�
(1, A) �� (3, C) �� 'm' ��Ϊ 'f' ��
(2, B) �� (4, D) �� 'f' ��Ϊ 'm' ��
```
