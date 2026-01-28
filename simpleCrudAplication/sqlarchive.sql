--
-- PostgreSQL database dump
--

\restrict WW3haY2JNSuTPadubihxtB8LVUGi3bXTdB06oj1juXlpY7WJceHcIklUX5mhew4

-- Dumped from database version 18.1
-- Dumped by pg_dump version 18.1

-- Started on 2026-01-28 01:11:26

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 222 (class 1255 OID 16410)
-- Name: fn_log_operacoes(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.fn_log_operacoes() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
    IF TG_OP = 'INSERT' THEN
        INSERT INTO log_operacoes (operacao)
        VALUES ('INSERT');

    ELSIF TG_OP = 'UPDATE' THEN
        INSERT INTO log_operacoes (operacao)
        VALUES ('UPDATE');

    ELSIF TG_OP = 'DELETE' THEN
        INSERT INTO log_operacoes (operacao)
        VALUES ('DELETE');
    END IF;

    RETURN NEW;
END;
$$;


ALTER FUNCTION public.fn_log_operacoes() OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 219 (class 1259 OID 16389)
-- Name: cadastros; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.cadastros (
    texto text CONSTRAINT cadastro_texto_not_null NOT NULL,
    numero integer CONSTRAINT cadastro_numero_not_null NOT NULL,
    CONSTRAINT ck_numero_maior_que_zero CHECK ((numero > 0))
);


ALTER TABLE public.cadastros OWNER TO postgres;

--
-- TOC entry 221 (class 1259 OID 16400)
-- Name: log_operacoes; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.log_operacoes (
    id integer NOT NULL,
    data_hora timestamp without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    operacao character varying(10) NOT NULL
);


ALTER TABLE public.log_operacoes OWNER TO postgres;

--
-- TOC entry 220 (class 1259 OID 16399)
-- Name: log_operacoes_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.log_operacoes_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.log_operacoes_id_seq OWNER TO postgres;

--
-- TOC entry 4920 (class 0 OID 0)
-- Dependencies: 220
-- Name: log_operacoes_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.log_operacoes_id_seq OWNED BY public.log_operacoes.id;


--
-- TOC entry 4760 (class 2604 OID 16403)
-- Name: log_operacoes id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.log_operacoes ALTER COLUMN id SET DEFAULT nextval('public.log_operacoes_id_seq'::regclass);


--
-- TOC entry 4766 (class 2606 OID 16409)
-- Name: log_operacoes log_operacoes_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.log_operacoes
    ADD CONSTRAINT log_operacoes_pkey PRIMARY KEY (id);


--
-- TOC entry 4764 (class 2606 OID 16398)
-- Name: cadastros pk_cadastro; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.cadastros
    ADD CONSTRAINT pk_cadastro PRIMARY KEY (numero);


--
-- TOC entry 4767 (class 2620 OID 16411)
-- Name: cadastros trg_log_cadastro; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER trg_log_cadastro AFTER INSERT OR DELETE OR UPDATE ON public.cadastros FOR EACH ROW EXECUTE FUNCTION public.fn_log_operacoes();


-- Completed on 2026-01-28 01:11:26

--
-- PostgreSQL database dump complete
--

\unrestrict WW3haY2JNSuTPadubihxtB8LVUGi3bXTdB06oj1juXlpY7WJceHcIklUX5mhew4

