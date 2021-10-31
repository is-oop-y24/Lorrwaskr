﻿using System;
using System.Collections.Generic;
using System.Linq;
using Isu.Services;

namespace Isu.Tools
{
    public class StudentsRepository : IRepository<Student>
    {
        private List<Student> _students;

        public StudentsRepository()
        {
            _students = new List<Student>();
        }

        public void Save(Student newStudent)
        {
            Student oldStudent = _students.Find(group => group.ID == newStudent.ID);
            if (oldStudent != null)
            {
                _students.Add(newStudent);
                _students.Remove(oldStudent);
            }
            else
            {
                _students.Add(newStudent);
            }
        }

        public Student Get(Guid id)
        {
            return _students.Find(group => group.ID == id);
        }

        public List<Student> GetAll()
        {
            return _students;
        }

        public Student FindByName(string name)
        {
            return _students.First(student => student.Name == name);
        }

        public List<Student> FindByGroup(Guid groupId)
        {
            return _students.FindAll(student => student.GroupID == groupId);
        }
    }
}