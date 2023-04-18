import http from '../HttpCommon.js';

const getAll = () => {
  return http.get('/permissions-type/get-permissions-type');
};

const PermissionTypeService = {
  getAll
};

export default PermissionTypeService