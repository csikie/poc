import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from '@/components/ui/table';
import useFetchData from '@/hooks/useFetchData';

function FetchData() {
  const { data } = useFetchData();
  return (
    <div className="flex flex-col m-auto">
      <Table>
        <TableHeader>
          <TableRow>
            <TableHead className='w-[200px]'>Date</TableHead>
            <TableHead>Summary</TableHead>
            <TableHead>TemperatureC</TableHead>
          </TableRow>
        </TableHeader>
        <TableBody>
          {data.map(({ date, summary, temperatureC }) => (
            <TableRow key={date}>
              <TableCell>{date}</TableCell>
              <TableCell className='font-medium'>{summary}</TableCell>
              <TableCell>{temperatureC}</TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </div>
  );
}

export default FetchData;
