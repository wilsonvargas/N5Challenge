import {Alert} from 'react-bootstrap';
import {Link} from 'react-router-dom';

function Message(props) {
    return (
        <Alert key={props.type} variant={props.type}>
            {props.message}
            {props.type !== 'danger' && (
                <Alert.Link as={Link} to="/">
                    Ir al inicio
                </Alert.Link>
            )}
        </Alert>
    );
}

export default Message;
