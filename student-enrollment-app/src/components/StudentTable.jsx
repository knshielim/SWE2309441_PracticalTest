import StudentTableItem from "./StudentTableItem";

function StudentTable({ students, onDelete, onToggle }) {
  return (
    <div className="overflow-x-auto">
      <table className="min-w-full bg-white rounded-lg shadow-md">
        <thead>
          <tr className="bg-blue-600 text-white">
            <th className="py-3 px-4">ID</th>
            <th className="py-3 px-4">Student Name</th>
            <th className="py-3 px-4">Programme</th>
            <th className="py-3 px-4">Enrollment Status</th>
            <th className="py-3 px-4">Actions</th>
          </tr>
        </thead>
        <tbody>
          {students.map((student, idx) => (
            <StudentTableItem
              key={student.id}
              student={student}
              idx={idx}
              onDelete={onDelete}
              onToggle={onToggle}
            />
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default StudentTable;