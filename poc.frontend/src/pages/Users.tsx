import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from '@/components/ui/table';
import useUsers from '@/hooks/useUsers';

function Users() {
  const { data } = useUsers();

  return (
    <div className='flex flex-col m-auto'>
      <Table>
        <TableHeader>
          <TableRow>
            <TableHead className='w-[200px]'>Email</TableHead>
            <TableHead>Role</TableHead>
          </TableRow>
        </TableHeader>
        <TableBody>
          {data.map(({ userId, email, roles }) => (
            <TableRow key={userId}>
              <TableCell>{email}</TableCell>
              <TableCell className='font-medium'>{roles.length === 0 ? 'None' : roles.join(',')}</TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </div>
  );
}

export default Users;
