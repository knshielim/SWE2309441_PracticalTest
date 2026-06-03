import { useState, useEffect } from "react";
import { fetchStudents, deleteStudent, updateStudent } from "./API/StudentAPI";
import AddStudent from "./components/AddStudent";
import StudentTable from "./components/StudentTable";

function App() {
  const [students, setStudents] = useState([]);

  useEffect(() => {
    fetchData();
  }, []);

  const fetchData = async () => {
    try {
      const data = await fetchStudents();
      const sorted = [...data].sort((a, b) => a.id - b.id);
      setStudents(sorted);
    } catch (error) {
      console.error("Error fetching students:", error);
    }
  };

  const handleDelete = async (id) => {
    await deleteStudent(id);
    setStudents(students.filter((s) => s.id !== id));
  };

  const handleToggle = async (student) => {
    const updated = {
      ...student,
      enrollmentStatus:
        student.enrollmentStatus === "Active" ? "Pending" : "Active",
    };
    await updateStudent(student.id, updated);
    fetchData();
  };

  return (
    <div className="min-h-screen bg-gray-100 p-8">
      <h1 className="text-4xl font-bold mb-8 text-center text-blue-700">
        Student Enrollment Management System
      </h1>

      <StudentTable
        students={students}
        onDelete={handleDelete}
        onToggle={handleToggle}
      />

      <div className="mt-12">
        <AddStudent onStudentAdded={fetchData} />
      </div>
    </div>
  );
}

export default App;