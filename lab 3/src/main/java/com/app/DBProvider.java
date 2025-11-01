package com.app;

import com.app.*;
import java.util.List;
import java.lang.Runnable;
import jakarta.persistence.*;
import jakarta.persistence.criteria.*;

import org.hibernate.Session;
import org.hibernate.Criteria;
import org.hibernate.Transaction;
import org.hibernate.SessionFactory;
import org.hibernate.cfg.Configuration;



public class DBProvider {
//	private static EntityManagerFactory entityManagerFactory;
//	private static EntityManager entityManager;
//
//	public static void init() {
//		if (entityManagerFactory == null) {
//			entityManagerFactory = Persistence.createEntityManagerFactory("characters-games-publishers");
//			entityManager = entityManagerFactory.createEntityManager();
//		}
//	}
//
//	public static EntityManager getEntityManager() {
//		return entityManager;
//	}
//
//	public static void begin() {
//		entityManager.getTransaction().begin();
//	}
//
//	public static void commit() {
//		entityManager.getTransaction().commit();
//	}
//
//	public static void transact(Runnable func) {
//		entityManager.getTransaction().begin();
//		func.run();
//		entityManager.getTransaction().commit();
//	}
//
//	public static <T> T getById(Class<T> type, int id) {
//		return entityManager.find(type, id);
//	}
//
//	public static <T> List<T> getAll(Class<T> type) {
//		CriteriaQuery<T> cq = entityManagerFactory.getCriteriaBuilder().createQuery(type);
//		cq.select(cq.from(type));
//		return entityManager.createQuery(cq).getResultList();
//	}
//
//	// сохранение
//	public static <T> void persist(T entity) {
//        entityManager.getTransaction().begin();
//		entityManager.persist(entity);
//        entityManager.getTransaction().commit();
//	}
//
//	public static <T> void remove(T entity) {
//        entityManager.getTransaction().begin();
//		entityManager.remove(entity);
//        entityManager.getTransaction().commit();
//	}
//
//	public static void close() {
//		if (entityManagerFactory != null) {
//			entityManager.close();
//			entityManagerFactory.close();
//		}
//	}

	private static SessionFactory sessionFactory;


	public static SessionFactory getSessionFactory() {
		return sessionFactory;
	}

	public static void close() {
		getSessionFactory().close();
	}

	public static void init() {
		sessionFactory = new Configuration().configure().buildSessionFactory();
	}

	public static void transact(Runnable func) {
		Session session = getSessionFactory().openSession();
		Transaction tx = session.beginTransaction();
		func.run();
		tx.commit();
	}

	public static <T> T getById(Class<T> type, int id) {
		Session session = getSessionFactory().openSession();
		return session.get(type, id);
	}

	public static <T> List<T> getAll(Class<T> type) {
		CriteriaQuery<T> cq = getSessionFactory().getCriteriaBuilder().createQuery(type);
		cq.select(cq.from(type));
		return getSessionFactory().openSession().createQuery(cq).getResultList();
	}

	// сохранение
	public static <T> void persist(T entity) {
		Session session = getSessionFactory().openSession();
		Transaction tx = session.beginTransaction();
		session.persist(entity);
		tx.commit();
//		session.getTransaction().begin();
//		session.persist(entity);
//		session.getTransaction().commit();
	}

	public static <T> void remove(T entity) {
		Session session = getSessionFactory().openSession();
		Transaction tx = session.beginTransaction();
		session.delete(entity);
		tx.commit();
	}

}