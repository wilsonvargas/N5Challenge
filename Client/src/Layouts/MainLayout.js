import React from "react";
import { Navbar, Nav, Container } from "react-bootstrap";
import { Link, Outlet } from "react-router-dom";

function MainLayout() {
	return (
		<div>
			<Navbar className="mainLayout" variant="dark" expand="lg">
				<Container>
					<Navbar.Brand as={Link} to="/">
						N5Challenge
					</Navbar.Brand>
					<Navbar.Toggle aria-controls="basic-navbar-nav" />
					<Navbar.Collapse id="basic-navbar-nav">
						<Nav className="me-auto">
							<Nav.Link as={Link} to="/">
								Inicio
							</Nav.Link>
							<Nav.Link as={Link} to="/create">
								Crear
							</Nav.Link>
						</Nav>
					</Navbar.Collapse>
				</Container>
			</Navbar>
			<section>
				<Outlet></Outlet>
			</section>
		</div>
	);
}

export default MainLayout;
