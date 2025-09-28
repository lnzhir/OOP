package io.github.nickacpt.jmenu.annotations;

import java.lang.annotation.Inherited;
import java.lang.annotation.Retention;
import java.lang.annotation.RetentionPolicy;

//@Inherited
@Retention(RetentionPolicy.RUNTIME)
public @interface Option {
    public int ordinal();
    public char key();
    public String description();
}
