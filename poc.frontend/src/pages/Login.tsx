import { Button } from '@/components/ui/button';
import { Card, CardContent, CardDescription, CardFooter, CardHeader, CardTitle } from '@/components/ui/card';
import { Input } from '@/components/ui/input';
import { Label } from '@/components/ui/label';
import useSupabaseClient from '@/hooks/useSupabaseClient';
import userStore from '@/stores/userStore';
import { useState } from 'react';
import { useNavigate } from 'react-router-dom';

export default function Login() {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const client = useSupabaseClient();
  const setUser = userStore((state) => state.setUser);
  const setSession = userStore((state) => state.setSession);
  const setPermission = userStore((state) => state.setPermission);
  const navigate = useNavigate();

  const handleSubmit = (e: React.MouseEvent) => {
    e.preventDefault();
    
    client.auth.signInWithPassword({
      email,
      password,
    }).then(({data: { user, session } }) => {
      setUser(user);
      setSession(session);
      const perm = user?.user_metadata?.permission.replace('Permission', '');
      setPermission(parseInt(perm));
      navigate('/');
    });
  };

  return (
    <div className='flex justify-center items-center h-screen'>
      <Card className='w-full max-w-sm'>
        <CardHeader>
          <CardTitle className='text-2xl'>Login</CardTitle>
          <CardDescription>Enter your email below to login to your account.</CardDescription>
        </CardHeader>
        <CardContent className='grid gap-4'>
          <div className='grid gap-2'>
            <Label htmlFor='email'>Email</Label>
            <Input
              id='email'
              type='email'
              placeholder='m@example.com'
              required
              onChange={(e) => setEmail(e.target.value)}
            />
          </div>
          <div className='grid gap-2'>
            <Label htmlFor='password'>Password</Label>
            <Input
              id='password'
              type='password'
              required
              onChange={(e) => setPassword(e.target.value)}
            />
          </div>
        </CardContent>
        <CardFooter>
          <Button onClick={(e) => handleSubmit(e)} className='w-full'>Sign in</Button>
        </CardFooter>
      </Card>
    </div>
  );
}
