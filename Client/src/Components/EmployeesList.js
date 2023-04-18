import {React, useState, useEffect} from 'react';
import PermissionService from '../Services/PermissionService';
import {Button, Table} from 'react-bootstrap';
import Loading from './Common/Loading';
import Message from './Common/Message';
import {format} from 'date-fns';
import {Link} from 'react-router-dom';

function EmployeesList() {
    const [permissions, setPermissions] = useState([]);
    const [isLoading, setIsLoading] = useState(true);
    const [error, setError] = useState('');

    useEffect(() => {
        retrievePermissions();
    }, []);

    const retrievePermissions = () => {
        PermissionService.getAll()
            .then((response) => {
                setPermissions(response.data);
                setIsLoading(false);
            })
            .catch((e) => {
                setIsLoading(false);
                setError('Error al obtener la lista de permisos.');
            });
    };
    return (
        <div>
            {isLoading && <Loading />}
            {error && <Message type="danger" message={error} />}
            {!error && !isLoading && permissions && (
                <Table striped bordered hover>
                    <thead>
                        <tr>
                            <th>Nombre</th>
                            <th>Apellido</th>
                            <th>Tipo de permiso</th>
                            <th>Fecha de permiso</th>
                            <th>Acción</th>
                        </tr>
                    </thead>
                    <tbody>
                        {permissions.map((permission) => (
                            <tr key={permission.id}>
                                <td>{permission.employeeName}</td>
                                <td>{permission.employeeLastName}</td>
                                <td>
                                    <p>
                                        {permission.permissionType.description}
                                    </p>
                                </td>
                                <td>
                                    {format(
                                        new Date(permission.permissionDate),
                                        'dd-MM-yyyy'
                                    )}
                                </td>
                                <td>
                                    <Button
                                        className="btn-edit"
                                        as={Link}
                                        to="edit"
                                        state={permission}
                                    >
                                        <i className="bi bi-pencil" /> Editar
                                    </Button>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </Table>
            )}
        </div>
    );
}

export default EmployeesList;
