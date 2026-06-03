function StudentTableItem({ student, idx, onDelete, onToggle }) {
  return (
    <tr className={idx % 2 === 0 ? "bg-gray-50" : "bg-white"}>
      <td className="py-2 px-4 text-center">{student.id}</td>
      <td className="py-2 px-4">{student.studentName}</td>
      <td className="py-2 px-4">{student.programme}</td>
      <td className="py-2 px-4 text-center">
        <span
          className={`px-3 py-1 rounded-full text-sm font-medium ${
            student.enrollmentStatus === "Active"
              ? "bg-green-100 text-green-800"
              : "bg-orange-100 text-orange-800"
          }`}
        >
          {student.enrollmentStatus}
        </span>
      </td>
      <td className="py-2 px-4 text-center flex gap-2 justify-center">
        <button
          onClick={() => onToggle(student)}
          className="bg-yellow-500 text-white px-3 py-1 rounded hover:bg-yellow-700 transition"
          style={{ width: 110 }}
        >
          Toggle Status
        </button>
        <button
          onClick={() => onDelete(student.id)}
          className="bg-red-500 text-white px-3 py-1 rounded hover:bg-red-700 transition"
          style={{ width: 80 }}
        >
          Delete
        </button>
      </td>
    </tr>
  );
}

export default StudentTableItem;