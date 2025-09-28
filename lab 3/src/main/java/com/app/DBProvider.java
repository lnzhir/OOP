package com.app;

import com.app.*;
import org.hibernate.Query;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.Transaction;
import org.hibernate.cfg.Configuration;
import java.util.List;
import java.lang.Runnable;
import jakarta.persistence.*;
import jakarta.persistence.criteria.*;





public class DBProvider {
	private static EntityManagerFactory entityManagerFactory;
	private static EntityManager entityManager;

	public static void init() {
		if (entityManagerFactory == null) {
			entityManagerFactory = Persistence.createEntityManagerFactory("characters");
			entityManager = entityManagerFactory.createEntityManager();
		}
	}

	public static EntityManager getEntityManager() {
		return entityManager;
	}

	public static void begin() {
		entityManager.getTransaction().begin();
	}

	public static void commit() {
		entityManager.getTransaction().commit();
	}

	public static void transact(Runnable func) {
		entityManager.getTransaction().begin();
		func.run();
		entityManager.getTransaction().commit();
	}

	public static <T> List<T> getAll(Class<T> type) {
		CriteriaQuery<T> cq = entityManagerFactory.getCriteriaBuilder().createQuery(type);
		cq.select(cq.from(type));
		// List<T> result = em.createQuery(cq).getResultList();
		// em.close();
		// return result;
		return entityManager.createQuery(cq).getResultList();
	}

	/*public static <T> List<T> getAllEqual(Class<T> type, String column, Object parameter) {
		CriteriaBuilder cb = entityManagerFactory.getCriteriaBuilder();
		CriteriaQuery<T> cq = cb.createQuery(type);
		Root<T> root = cq.from(type);
		cq.select().where(cb.equal(root.get(column), parameter));
		return entityManager.createQuery(cq).getResultList();
	}*/

	public static <T> void add(T entity) {
		entityManager.getTransaction().begin();
		entityManager.persist(entity);
		entityManager.getTransaction().commit();
	}

	// сохранение
	public static <T> void persist(T entity) {
		entityManager.getTransaction().begin();
		entityManager.persist(entity);
		entityManager.getTransaction().commit();
	}

	public static <T> void remove(T entity) {
		entityManager.getTransaction().begin();
		entityManager.remove(entity);
		entityManager.getTransaction().commit();
	}

	public static void close() {
		if (entityManagerFactory != null) {
			entityManager.close();
			entityManagerFactory.close();
		}
	}
}