DO $$
DECLARE
    r RECORD;
BEGIN
    FOR r IN (
        SELECT tablename
        FROM pg_tables
        WHERE schemaname = 'public'
          AND tablename <> '__EFMigrationsHistory'
    )
    LOOP
        EXECUTE 'TRUNCATE TABLE public.'
            || quote_ident(r.tablename)
            || ' RESTART IDENTITY CASCADE';
    END LOOP;
END $$;