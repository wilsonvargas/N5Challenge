import http from '../HttpCommon.js';

const getAll = () => {
  return http.get('/permissions/get-permissions');
};

const create = data => {
  return http.post('/permissions/request-permission', data);
};

const update = data => {
  return http.put('/permissions/modify-permission', data);
};

const PermissionService = {
  getAll,
  create,
  update
};

export default PermissionService