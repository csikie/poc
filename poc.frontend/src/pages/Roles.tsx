import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from "@/components/ui/table";
import useRoles from "@/hooks/useRoles";

function Roles() {
  const { data } = useRoles();

  return (
    <div className="flex flex-col m-auto">
      <Table>
        <TableHeader>
          <TableRow>
            <TableHead className='w-[200px]'>Role</TableHead>
            <TableHead>Permission</TableHead>
          </TableRow>
        </TableHeader>
        <TableBody>
          {data.map(({ id, name, permissions }) => (
            <TableRow key={id}>
              <TableCell>{name}</TableCell>
              <TableCell className='font-medium'>{permissions}</TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </div>
  );
}

export default Roles;
