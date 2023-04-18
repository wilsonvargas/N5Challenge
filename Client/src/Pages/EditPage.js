import React from "react";
import EmployeesForm from "../Components/EmployeesForm";
import { useLocation } from "react-router-dom";

function EditPage() {
	const location = useLocation();
	const state = location.state;
	return <EmployeesForm formType="modify" employee={state} />;
}

export default EditPage;
