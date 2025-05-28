using task;

namespace task
{
    class Student
    {
        string studentName;
        int age;
        int id;
        List<Course> courses;

        public Student(string studentName, int age, int id, List<Course> courses)
        {
            this.studentName = studentName;
            this.age = age;
            this.id = id;
            this.courses = courses;
        }
        public bool Enroll(Course course)
        {
            if (courses.Count == 0)
            {
                Console.WriteLine("there is no enrolled courses");
                Console.WriteLine("do u want to add this course?");
                Console.WriteLine("Y/N");
                char option = Convert.ToChar(Console.ReadLine());
                option = char.ToLower(option);
                if (option == 'y')
                {
                    courses.Add(course);
                    return true;
                }
                else
                {
                    return false;
                }
            }

            for (int i = 0; i < courses.Count; i++)
            {
                if (courses[i].GetId() == course.GetId())
                {
                    Console.WriteLine("you are already enrolled in this course");
                    return false;
                }
            }

            Console.WriteLine("you are not in this course");
            Console.WriteLine("do u want to add this course?");
            Console.WriteLine("Y/N");
            char newOption = Convert.ToChar(Console.ReadLine());
            newOption = char.ToLower(newOption);
            if (newOption == 'y')
            {
                courses.Add(course);
                return true;
            }

            return false;
        }
        public int GetId()
        {
            return id;
        }
        public String PrintDetails()
        {
            string value;
            value = $"the student id {id}, name {studentName}, age {age} and courses :";
            if (courses.Count > 0)
            {
                for (int i = 0; i < courses.Count; i++)
                {
                    value = value + courses[i].GetTitle() + " , ";
                }
                return value;
            }
            else
            {
                return value = value + " zero";
            }
        }

    }
    class Instructor
    {
        int instructorId;
        string name;
        string specialization;

        public Instructor(int instructorId, string name, string specialization)
        {
            this.instructorId = instructorId;
            this.name = name;
            this.specialization = specialization;
        }
        public String PrintDetails()
        {
            string value;
            value = $"The instructor id {instructorId}, name {name}, specialization {specialization}";
            return value;
        }
        public int GetId()
        {
            return instructorId;
        }
        public string GetName()
        {
            return name;
        }
    }
    class Course
    {
        int CourseId;
        string Title;
        Instructor Instructor;

        public Course(int courseId, string title, Instructor instructor)
        {
            CourseId = courseId;
            Title = title;
            Instructor = instructor;
        }
        public String GetTitle()
        {
            return Title;
        }
        public int GetId()
        {
            return CourseId;
        }
        public String PrintDetails()
        {
            string value;
            value = $"the course id {CourseId}, title {Title}, instructor {Instructor.GetName()}";
            return value;
        }
    }
    class StudentManager
    {
        List<Student> Students;
        List<Course> Courses;
        List<Instructor> Instructors;

        public StudentManager(List<Student> students, List<Course> courses, List<Instructor> instructors)
        {
            Students = students;
            Courses = courses;
            Instructors = instructors;
        }
        public bool AddStudent(Student student)
        {
           
            for (int i = 0; i < Students.Count; i++)
            {
                if (Students[i].GetId() == student.GetId())
                {
                    Console.WriteLine("Student with this ID already exists.");
                    return false;
                }
            }
           
            Students.Add(student);
            return true;
        }
        public Student FindStudent(int id) {
            for(int i = 0; i < Students.Count; i++)
            {
                if (id == Students[i].GetId()) { 
                return Students[i];
                }
            }
            return default;
        }
        public Course FindCourse(int id)
        {
            for (int i = 0; i < Courses.Count; i++)
            {
                if (id == Courses[i].GetId())
                {
                    return Courses[i];
                }
            }
            return default;
        }
        public bool EnrollStudentInCourse(int studentId, int courseId)
        {
            Student student = FindStudent(studentId);
            Course course = FindCourse(courseId);
            return student.Enroll(course);
        }
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        List<Student> students = [];
        List<Course> courses = [];
        List<Instructor> instructors = [];
        StudentManager studentManager = new StudentManager(students, courses, instructors);
        int choice = -1;
        while (choice != 12)
        {
            Console.WriteLine("Hello and Welcome");
            Console.WriteLine("You can choose one of these options");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Add Instructor ");
            Console.WriteLine("3. Add Course");
            Console.WriteLine("4. Enroll Student in Course");
            Console.WriteLine("5. Show All Students");
            Console.WriteLine("6. Show All Courses");
            Console.WriteLine("7. Show All Instructors ");
            Console.WriteLine("8. Find the student by id or name");
            Console.WriteLine("9. Fine the course by id or name");
            Console.WriteLine("10.Update Student info");
            Console.WriteLine("11.Delete Student");
            Console.WriteLine("12. Exit ");
            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Please enter the Student data");
                    Console.WriteLine("the student name , age and id");
                    string studentName = Console.ReadLine();
                    int studentAge = Convert.ToInt32(Console.ReadLine());
                    int studentId = Convert.ToInt32(Console.ReadLine());
                    List<Course> studentCourses = [];
                    Student student = new Student(studentName, studentAge, studentId, studentCourses);
                    bool flag = studentManager.AddStudent(student);
                    if (flag)
                    {
                        Console.WriteLine("now the student data are :");
                        Console.WriteLine(student.PrintDetails());
                        break;
                    }
                    else
                    {
                        break;
                    }
                case 2:
                    Console.WriteLine("Please enter the instructor data");
                    Console.WriteLine("the instructor name , specialization and id");
                    string instructorName = Console.ReadLine();
                    string specialization = Console.ReadLine();
                    int instructorId = Convert.ToInt32(Console.ReadLine());
                    flag = false;
                    for (int i = 0; i < instructors.Count; i++)
                    {
                        if (instructorId == instructors[i].GetId())
                        {
                            Console.WriteLine("this id is not avaliable");
                            flag = true;
                            break;
                        }
                    }
                    if (flag)
                    {
                        break;
                    }
                    Instructor instructor = new Instructor(instructorId, instructorName, specialization);
                    Console.WriteLine("now the instructor data are :");
                    Console.WriteLine(instructor.PrintDetails());
                    instructors.Add(instructor);
                    break;
                case 3:
                    Console.WriteLine("Please enter the course data");
                    Console.WriteLine("the course title , instructorId and id");
                    string title = Console.ReadLine();
                    int instructId = Convert.ToInt32(Console.ReadLine());
                    Instructor instructor1 = default;
                    for (int i = 0; i < instructors.Count; i++)
                    {
                        if (instructId == instructors[i].GetId())
                        {
                            instructor1 = instructors[i];
                        }
                    }
                    flag = false;
                    int courseId = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < courses.Count; i++)
                    {
                        if (courseId == courses[i].GetId())
                        {
                            Console.WriteLine("this id is not avaliable");
                            flag = true;
                            break;
                        }
                    }
                    if (flag)
                    {
                        break;
                    }
                    Course course = new Course(courseId, title, instructor1);
                    Console.WriteLine("now the course data are :");
                    Console.WriteLine(course.PrintDetails());
                    courses.Add(course);
                    break;
                case 4:
                    Console.WriteLine("please enter the course id and the student id ");
                    int cId = Convert.ToInt32(Console.ReadLine());
                    int sId = Convert.ToInt32(Console.ReadLine());
                    studentManager.EnrollStudentInCourse(sId, cId);
                    break;
                case 5:
                    if (students.Count == 0)
                    {
                        Console.WriteLine("there is no students available");
                        break;
                    }
                    else
                    {
                        for (int i = 0; i < students.Count; i++)
                        {
                            Console.WriteLine(students[i].PrintDetails());
                        }
                        break;
                    }
                case 6:
                    if (courses.Count == 0)
                    {
                        Console.WriteLine("there is no courses available");
                        break;
                    }
                    else
                    {
                        for (int i = 0; i < courses.Count; i++)
                        {
                            Console.WriteLine(courses[i].PrintDetails());
                        }
                        break;
                    }
                case 7:
                    if (instructors.Count == 0)
                    {
                        Console.WriteLine("there is no instructors available");
                        break;
                    }
                    else
                    {
                        for (int i = 0; i < instructors.Count; i++)
                        {
                            Console.WriteLine(instructors[i].PrintDetails());
                        }
                        break;
                    }
                case 8:
                    Console.WriteLine("enter the student id please");
                    int id=Convert.ToInt32(Console.ReadLine());
                    Student s = studentManager.FindStudent(id);
                    Console.WriteLine(s.PrintDetails());
                    break;
                case 9:
                    Console.WriteLine("enter the course id please");
                    int courseid = Convert.ToInt32(Console.ReadLine());
                    Course c = studentManager.FindCourse(courseid);
                    Console.WriteLine(c.PrintDetails());
                    break;
                case 10:
                    Console.WriteLine("enter the student id plz");
                    int updId = Convert.ToInt32(Console.ReadLine());
                    Student update= studentManager.FindStudent(updId);
                    Console.WriteLine("now rewrite the student data");
                    string updName = Console.ReadLine();
                    int updAge = Convert.ToInt32(Console.ReadLine());
                    List<Course> updCourses = [];
                    updId = Convert.ToInt32(Console.ReadLine());
                    update = new Student(updName, updAge, updId, updCourses);
                    students.Remove(update);
                    flag = studentManager.AddStudent(update);
                    if (flag)
                    {
                        Console.WriteLine("now the student data are :");
                        Console.WriteLine(update.PrintDetails());
                        break;
                    }
                    else
                    {
                        break;
                    }
                case 11:
                    Console.WriteLine("enter the student id to delete him");
                    int delId=Convert.ToInt32(Console.ReadLine());  
                    for(int i = 0; i < students.Count; i++)
                    {
                        if (students[i].GetId() == delId) {
                            students.RemoveAt(i);
                            Console.WriteLine("delete done");
                            break;
                        }
                    }
                    Console.WriteLine("there is an issue");
                    break;
                case 12:
                    break;
                default: 
                    Console.WriteLine("invalid option");
                    break;
            }
        }
    }
}