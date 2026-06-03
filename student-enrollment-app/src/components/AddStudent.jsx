import { useState } from "react";
import { addStudent } from "../API/StudentAPI";

function AddStudent({ onStudentAdded }) {
  const [form, setForm] = useState({
    studentName: "",
    programme: "",
    enrollmentStatus: "Active",
  });
  const [message, setMessage] = useState("");

  const handleChange = (e) => {
    setForm({ ...form, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      await addStudent(form);
      setMessage("Student registered successfully!");
      setForm({ studentName: "", programme: "", enrollmentStatus: "Active" });
      onStudentAdded();
    } catch (error) {
      setMessage("Failed to register student.");
    }
  };

  return (
    <div className="flex items-center justify-center mt-8">
      <form
        onSubmit={handleSubmit}
        className="bg-white p-8 rounded shadow-md w-full max-w-md"
      >
        <h2 className="text-2xl font-bold mb-6 text-blue-700 text-center">
          Register New Student
        </h2>
        <div className="mb-4">
          <label className="block mb-1">Student Name</label>
          <input
            name="studentName"
            value={form.studentName}
            onChange={handleChange}
            required
            className="w-full border px-3 py-2 rounded"
          />
        </div>
        <div className="mb-4">
          <label className="block mb-1">Programme</label>
          <input
            name="programme"
            value={form.programme}
            onChange={handleChange}
            required
            className="w-full border px-3 py-2 rounded"
          />
        </div>
        <div className="mb-6">
          <label className="block mb-1">Enrollment Status</label>
          <select
            name="enrollmentStatus"
            value={form.enrollmentStatus}
            onChange={handleChange}
            className="w-full border px-3 py-2 rounded"
          >
            <option value="Active">Active</option>
            <option value="Pending">Pending</option>
          </select>
        </div>
        <button
          type="submit"
          className="w-full bg-blue-600 text-white py-2 rounded hover:bg-blue-700 transition"
        >
          Register Student
        </button>
        {message && (
          <div className="mt-4 text-center text-green-600">{message}</div>
        )}
      </form>
    </div>
  );
}

export default AddStudent;