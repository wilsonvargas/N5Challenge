import React, {useEffect, useState} from 'react';
import {Button, Col, Container, Form, Row} from 'react-bootstrap';
import PermissionTypeService from '../Services/PermissionTypeService';
import Loading from './Common/Loading';
import PermissionService from '../Services/PermissionService';
import Message from './Common/Message';

function EmployeesForm(props) {
    const [permissionsType, setPermissionsType] = useState([]);
    const [isLoading, setIsLoading] = useState(true);
    const [isError, setIsError] = useState(false);
    const [message, setMessage] = useState('');
    const [submitted, setSubmitted] = useState(false);

    let initialEmployeeState = {
        id: null,
        employeeName: '',
        employeeLastName: '',
        permissionTypeId: null,
    };

    let buttonValue = 'Crear';
    let loadingButtonValue = 'Creando...';

    if (props.employee) {
        initialEmployeeState = props.employee;
        buttonValue = 'Editar';
        loadingButtonValue = 'Editando...';
    }

    const [employee, setEmployee] = useState(initialEmployeeState);

    useEffect(() => {
        retrievePermissionsType();
    }, []);

    const handleInputChange = (event) => {
        const {name, value} = event.target;
        setEmployee({...employee, [name]: value});
    };

    const resetFields = (isSuccess, message) => {
        setIsLoading(!isSuccess);
        setIsError(!isSuccess);
        setMessage(message);
    };

    const fieldsHasErrors = () => {
        if (
            !employee.employeeName ||
            !employee.employeeLastName ||
            !employee.permissionTypeId ||
            isNaN(Number(employee.permissionTypeId))
        ) {
            setIsError(true);
            setMessage('Todos los campos son obligatorios. ');
            return true;
        } else {
            return false;
        }
    };

    const saveEmployee = () => {
        setSubmitted(true);
        if (fieldsHasErrors()) return null;
        var data = {
            employeeName: employee.employeeName,
            employeeLastName: employee.employeeLastName,
            permissionTypeId: employee.permissionTypeId,
        };
        setIsLoading(true);
        PermissionService.create(data)
            .then((response) => {
                resetFields(true, 'Los datos se agregaron correctamente. ');
                setEmployee(initialEmployeeState);
            })
            .catch((e) => {
                resetFields(false, 'Hubo un problema al registrar los datos.');
            });
    };

    const updateEmployee = () => {
        setSubmitted(true);
        if (fieldsHasErrors()) return null;
        setIsLoading(true);
        employee.permissionType = null;
        PermissionService.update(employee)
            .then((response) => {
                resetFields(true, 'Los datos se actualizaron correctamente. ');
            })
            .catch((e) => {
                resetFields(false, 'Hubo un problema al actualizar los datos.');
            });
    };

    const retrievePermissionsType = () => {
        PermissionTypeService.getAll()
            .then((response) => {
                setPermissionsType(response.data);
                setIsLoading(false);
            })
            .catch((e) => {
                setIsLoading(false);
            });
    };
    return (
        <Container className="container-form">
            <Form className="col-lg-6">
                <Row>
                    <Col>
                        <Form.Control
                            placeholder="Nombres"
                            id="employeeName"
                            name="employeeName"
                            onChange={handleInputChange}
                            value={employee.employeeName}
                        />
                    </Col>
                    <Col>
                        <Form.Control
                            placeholder="Apellidos"
                            id="employeeLastName"
                            name="employeeLastName"
                            onChange={handleInputChange}
                            value={employee.employeeLastName}
                        />
                    </Col>
                </Row>
                <br></br>
                {isLoading ? (
                    <Loading />
                ) : (
                    <Form.Select
                        aria-label="Tipos de Permisos"
                        id="permissionTypeId"
                        name="permissionTypeId"
                        onChange={handleInputChange}
                        defaultValue={employee.permissionTypeId}
                    >
                        <option>Selecciona el tipo de permiso</option>
                        {permissionsType.map((permissionType) => (
                            <option
                                key={permissionType.id}
                                value={permissionType.id}
                            >
                                {permissionType.description}
                            </option>
                        ))}
                    </Form.Select>
                )}
                <br></br>
                {submitted && (
                    <Message
                        type={isError ? 'danger' : 'success'}
                        message={message}
                    />
                )}

                <Button
                    className="btn-create"
                    disabled={isLoading}
                    onClick={props.employee ? updateEmployee : saveEmployee}
                >
                    {isLoading ? loadingButtonValue : buttonValue}
                </Button>
            </Form>
        </Container>
    );
}

export default EmployeesForm;
