import Spinner from "react-bootstrap/Spinner";

function Loading() {
	return (
		<>
			<Spinner animation="grow" variant="dark" size="sm" />
			<Spinner animation="grow" variant="dark" size="sm" />
			<Spinner animation="grow" variant="dark" size="sm" />
		</>
	);
}

export default Loading;
