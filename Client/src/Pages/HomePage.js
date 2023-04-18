import React from "react";
import EmployeesList from "../Components/EmployeesList";
import { Button, Container } from "react-bootstrap";
import { Link } from "react-router-dom";

function HomePage() {
	return (
		<Container>
			<Button className="btn-create" as={Link} to="/create">
				Crear empleado
			</Button>
			<EmployeesList />
		</Container>
	);
}

export default HomePage;
