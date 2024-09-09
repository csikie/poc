import { useEffect } from 'react';
import { Link, Outlet, useNavigate } from 'react-router-dom';
import userStore from './stores/userStore';
import { Button } from './components/ui/button';
import Permissions from './constants/Permissions';
import useSupabaseClient from './hooks/useSupabaseClient';

function App() {
  const client = useSupabaseClient();
  const router = useNavigate();
  const userData = userStore((state) => state.user);
  const permission = userStore((state) => state.permission);
  const setUser = userStore((state) => state.setUser);
  const setSession = userStore((state) => state.setSession);
  const setPermission = userStore((state) => state.setPermission);

  useEffect(() => {
    //client.auth.updateUser({ data: { permission: 'Permission14' } });

    if (!userData) {
      client.auth.getUser().then(({ data: { user } }) => {
        if (!user) {
          router('/login');
        }

        setUser(user);
        const perm = user?.user_metadata?.permission.replace('Permission', '');
        console.log('perm', perm);
        setPermission(parseInt(perm));
      });
    }

    client.auth.onAuthStateChange((_, session) => {
      if (!session) {
        setUser(null);
        setSession(null);
        router('/login');
      }

      setSession(session);
    });
  }, [client.auth, router, setPermission, setSession, setUser, userData]);

  const signOut = async () => {
    const { error } = await client.auth.signOut();

    if (error) {
      console.error('Sign out error', error);
    }
  };

  const links = [
    { to: '/counter', label: 'Counter', permission: Permissions.Counter },
    { to: '/fetch-data', label: 'Fetch data', permission: Permissions.Fetch },
    { to: '/users', label: 'Users', permission: Permissions.ViewUsers },
    { to: '/roles', label: 'Roles', permission: Permissions.ViewRoles },
    { to: '/access-control', label: 'Access control', permission: Permissions.ViewAccessControl },
  ];

  return (
    <div className='flex'>
      <div className='flex flex-col space-y-2'>
        <div>Routes</div>
        {links
          .filter(({ permission: p }) => (permission! & p) !== 0)
          .map(({ to, label }) => (
            <Link
              key={to}
              to={to}>
              {label}
            </Link>
          ))}
        <Button onClick={signOut}>Sign out</Button>
      </div>
      <Outlet />
    </div>
  );
}

export default App;
